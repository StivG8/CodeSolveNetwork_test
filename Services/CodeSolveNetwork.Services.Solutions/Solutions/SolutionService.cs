using AutoMapper;
using CodeSolveNetwork.Common.Exceptions;
using CodeSolveNetwork.Common.Validator;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace CodeSolveNetwork.Services.Solutions
{
    public class SolutionService : ISolutionService
    {
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<CreateSolutionModel> createSolutionModelValidator;
        private readonly IModelValidator<UpdateSolutionModel> updateSolutionModelValidator;

        public SolutionService(
            IDbContextFactory<MainDbContext> dbContextFactory,
            IMapper mapper,
            IModelValidator<CreateSolutionModel> createSolutionModelValidator,
            IModelValidator<UpdateSolutionModel> updateSolutionModelValidator
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.createSolutionModelValidator = createSolutionModelValidator;
            this.updateSolutionModelValidator = updateSolutionModelValidator;
        }

        public async Task<IEnumerable<SolutionModel>> GetAll()
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var solutions = await context.Solutions
                .Include(x => x.Task)
                .ToListAsync();

            var result = mapper.Map<IEnumerable<SolutionModel>>(solutions);

            return result;
        }

        public async Task<SolutionModel> GetById(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var solution = await context.Solutions
                .Include(x => x.Task)
                .FirstOrDefaultAsync(x => x.Uid == id);

            var result = mapper.Map<SolutionModel>(solution);

            return result;
        }

        public async Task<SolutionModel> Create(CreateSolutionModel model)
        {
            await createSolutionModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var solution = mapper.Map<Solution>(model);

            await context.Solutions.AddAsync(solution);

            await context.SaveChangesAsync();

            //await action.PublicateBook(new PublicateBookModel()
            //{
            //    Id = book.Id,
            //    Title = book.Title,
            //    Description = book.Description
            //});

            return mapper.Map<SolutionModel>(solution);
        }

        public async Task Update(Guid id, UpdateSolutionModel model)
        {
            await updateSolutionModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var solutioin = await context.Solutions.Where(x => x.Uid == id).FirstOrDefaultAsync();

            solutioin = mapper.Map(model, solutioin);

            context.Solutions.Update(solutioin);

            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var solution = await context.Solutions.Where(x => x.Uid == id).FirstOrDefaultAsync();

            if (solution == null)
                throw new ProcessException($"Solution (ID = {id}) not found.");

            context.Solutions.Remove(solution);

            await context.SaveChangesAsync();
        }
    }
}

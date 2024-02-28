
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeSolveNetwork.Common.Exceptions;
using CodeSolveNetwork.Common.Validator;
using CodeSolveNetwork.Context.Context;
using CodeSolveNetwork.Context.Entities;
using CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages.Models;
using Task = System.Threading.Tasks.Task;
using CodeSolveNetwork.Services.Actions;

namespace CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages
{
    public class ProgrammingLanguageService : IProgrammingLanguageService
    {
        private readonly IDbContextFactory<MainDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly IAction action;
        private readonly IModelValidator<CreateProgrammingLanguageModel> createProgrammingLanguageModelValidator;
        private readonly IModelValidator<UpdateProgrammingLanguageModel> ureateProgrammingLanguageModelValidator;

        public ProgrammingLanguageService(
            IDbContextFactory<MainDbContext> dbContextFactory,
            IMapper mapper,
            IAction action,
            IModelValidator<CreateProgrammingLanguageModel> createProgrammingLanguageModelValidator,
            IModelValidator<UpdateProgrammingLanguageModel> ureateProgrammingLanguageModelValidator
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.action = action;
            this.createProgrammingLanguageModelValidator = createProgrammingLanguageModelValidator;
            this.ureateProgrammingLanguageModelValidator = ureateProgrammingLanguageModelValidator;
        }
        public async Task<IEnumerable<ProgrammingLanguageModel>> GetAll()
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var programmingLanguages = await context.ProgrammingLanguages
                .Include(x => x.Tasks)
                .ToListAsync();

            var result = mapper.Map<IEnumerable<ProgrammingLanguageModel>>(programmingLanguages);

            return result;
        }

        public async Task<ProgrammingLanguageModel> GetById(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var programmingLanguage = await context.ProgrammingLanguages
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Uid == id);

            var result = mapper.Map<ProgrammingLanguageModel>(programmingLanguage);

            return result;
        }

        public async Task<ProgrammingLanguageModel> Create(CreateProgrammingLanguageModel model)
        {
            await createProgrammingLanguageModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var programmingLanguage = mapper.Map<ProgrammingLanguage>(model);

            await context.ProgrammingLanguages.AddAsync(programmingLanguage);

            await context.SaveChangesAsync();

            await action.PublicateProgrammingLanguage(new PublicateProgrammingLanguageModel()
            {
                Id=programmingLanguage.Id,
                Name=programmingLanguage.Name
            });

            return mapper.Map<ProgrammingLanguageModel>(programmingLanguage);
        }

        public async Task Update(Guid id, UpdateProgrammingLanguageModel model)
        {
            await ureateProgrammingLanguageModelValidator.CheckAsync(model);

            using var context = await dbContextFactory.CreateDbContextAsync();

            var programmingLanguage = await context.ProgrammingLanguages.Where(x => x.Uid == id).FirstOrDefaultAsync();

            programmingLanguage = mapper.Map(model, programmingLanguage);

            context.ProgrammingLanguages.Update(programmingLanguage);

            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            using var context = await dbContextFactory.CreateDbContextAsync();

            var programmingLanguage = await context.ProgrammingLanguages.Where(x => x.Uid == id).FirstOrDefaultAsync();

            if (programmingLanguage == null)
                throw new ProcessException($"ProgrammingLanguage (ID = {id}) not found.");

            context.ProgrammingLanguages.Remove(programmingLanguage);

            await context.SaveChangesAsync();
        }
    }
}

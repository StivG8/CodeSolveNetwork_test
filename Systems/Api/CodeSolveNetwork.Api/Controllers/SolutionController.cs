using Asp.Versioning;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.Solutions;
using Microsoft.AspNetCore.Mvc;

namespace CodeSolveNetwork.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Product")]
    [Route("v{version:apiVersion}/[controller]")]
    public class SolutionController : ControllerBase
    {
        private readonly IAppLogger logger;
        private readonly ISolutionService solutionService;
        public SolutionController(IAppLogger logger, ISolutionService solutionService)
        {
            this.logger = logger;
            this.solutionService = solutionService;
        }

        [HttpGet("")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IEnumerable<SolutionModel>> GetAll()
        {
            var result = await solutionService.GetAll();

            return result;
        }

        [HttpGet("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await solutionService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task<SolutionModel> Create(CreateSolutionModel request)
        {
            var result = await solutionService.Create(request);

            return result;
        }

        [HttpPut("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Update([FromRoute] Guid id, UpdateSolutionModel request)
        {
            await solutionService.Update(id, request);
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Delete([FromRoute] Guid id)
        {
            await solutionService.Delete(id);
        }
    }
}

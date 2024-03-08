using Asp.Versioning;
using CodeSolveNetwork.Common.Security;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages;
using CodeSolveNetwork.Services.ProgrammingLanguages.ProgrammingLanguages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSolveNetwork.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Product")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProgrammingLanguageController : ControllerBase
    {
        private readonly IAppLogger logger;
        private readonly IProgrammingLanguageService programmingLanguageService;

        public ProgrammingLanguageController(IAppLogger logger, IProgrammingLanguageService programmingLanguageService)
        {
            this.logger = logger;
            this.programmingLanguageService = programmingLanguageService;
        }

        [HttpGet("")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IEnumerable<ProgrammingLanguageModel>> GetAll()
        {
            var result = await programmingLanguageService.GetAll();

            return result;
        }

        [HttpGet("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await programmingLanguageService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task<ProgrammingLanguageModel> Create(CreateProgrammingLanguageModel request)
        {
            var result = await programmingLanguageService.Create(request);

            return result;
        }

        [HttpPut("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Update([FromRoute] Guid id, UpdateProgrammingLanguageModel request)
        {
            await programmingLanguageService.Update(id, request);
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Delete([FromRoute] Guid id)
        {
            await programmingLanguageService.Delete(id);
        }
    }
}

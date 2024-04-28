using Asp.Versioning;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.TaskCategories;
using Microsoft.AspNetCore.Mvc;

namespace CodeSolveNetwork.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Product")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TaskCategoryController : ControllerBase
    {
        private readonly IAppLogger logger;
        private readonly ITaskCategoryService taskCategoryService;
        public TaskCategoryController(IAppLogger logger, ITaskCategoryService taskCategoryService)
        {
            this.logger = logger;
            this.taskCategoryService = taskCategoryService;
        }

        [HttpGet("")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IEnumerable<TaskCategoryModel>> GetAll()
        {
            var result = await taskCategoryService.GetAll();

            return result;
        }

        [HttpGet("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await taskCategoryService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task<TaskCategoryModel> Create(CreateTaskCategoryModel request)
        {
            var result = await taskCategoryService.Create(request);

            return result;
        }

        [HttpPut("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Update([FromRoute] Guid id, UpdateTaskCategoryModel request)
        {
            await taskCategoryService.Update(id, request);
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Delete([FromRoute] Guid id)
        {
            await taskCategoryService.Delete(id);
        }
    }
}

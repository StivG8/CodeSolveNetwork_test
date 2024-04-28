using Asp.Versioning;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeSolveNetwork.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Product")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IAppLogger logger;
        private readonly ITaskService taskService;
        public TaskController(IAppLogger logger, ITaskService taskService)
        {
            this.logger = logger;
            this.taskService = taskService;
        }

        [HttpGet("")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IEnumerable<TaskModel>> GetAll()
        {
            var result = await taskService.GetAll();

            return result;
        }

        [HttpGet("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesRead)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await taskService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task<TaskModel> Create(CreateTaskModel request)
        {
            var result = await taskService.Create(request);

            return result;
        }

        [HttpPut("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Update([FromRoute] Guid id, UpdateTaskModel request)
        {
            await taskService.Update(id, request);
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(AppScopes.ProgrammingLanguagesWrite)]
        public async Task Delete([FromRoute] Guid id)
        {
            await taskService.Delete(id);
        }
    }
}

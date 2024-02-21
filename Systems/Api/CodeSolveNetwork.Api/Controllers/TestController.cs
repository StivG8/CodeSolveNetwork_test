using Asp.Versioning;
using CodeSolveNetwork.Services.Logger.Logger;
using Microsoft.AspNetCore.Mvc;

namespace CodeSolveNetwork.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "Test")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IAppLogger logger;

        public TestController(IAppLogger logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        [ApiVersion("1.0")]
        public int Test(int val)
        {
            logger.Debug(this, "Executed {0}, value={1}", "GET:/v1/test/", val);

            return val;
        }

        [HttpGet]
        [ApiVersion("2.0")]
        public int Test(int val, int val2)
        {
            logger.Debug(this, "Executed {0}, value={1}, value2={2}", "GET:/v2/test/", val, val2);

            return val * val2;
        }
    }
}

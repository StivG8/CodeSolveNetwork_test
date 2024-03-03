using Asp.Versioning;
using AutoMapper;
using CodeSolveNetwork.Services.UserAccount;
using Microsoft.AspNetCore.Mvc;

namespace CodeSolveNetwork.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Product")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<AccountsController> logger;
        private readonly IUserAccountService userAccountService;

        public AccountsController(IMapper mapper, ILogger<AccountsController> logger, IUserAccountService userAccountService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.userAccountService = userAccountService;
        }

        [HttpPost("")]
        public async Task<UserAccountModel> Register([FromQuery] RegisterUserAccountModel request)
        {
            var user = await userAccountService.Create(request);
            return user;
        }
    }

}

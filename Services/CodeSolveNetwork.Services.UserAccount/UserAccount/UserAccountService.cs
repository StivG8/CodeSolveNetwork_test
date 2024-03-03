using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CodeSolveNetwork.Common.Exceptions;
using CodeSolveNetwork.Common.Validator;
using CodeSolveNetwork.Context.Entities;

namespace CodeSolveNetwork.Services.UserAccount
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;

        public UserAccountService(
            IMapper mapper,
            UserManager<User> userManager,
            IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator
        )
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.registerUserAccountModelValidator = registerUserAccountModelValidator;
        }

        public async Task<bool> IsEmpty()
        {
            return !(await userManager.Users.AnyAsync());
        }

        public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
        {
            registerUserAccountModelValidator.Check(model);

            // Find user by email
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
                throw new ProcessException($"User account with email {model.Email} already exist.");

            // Create user account
            user = new User()
            {
                Status = UserStatus.Active,
                FullName = model.Name,
                UserName = model.Email,  // This is the login. We will equate it to email, although this is not necessary
                Email = model.Email,
                EmailConfirmed = true, // Since this is an course project, we immediately assume that the email has been confirmed. In a real project, most likely, we will need to confirm it via a link in the letter
                PhoneNumber = null,
                PhoneNumberConfirmed = false

                // There are also other interesting properties here. Look in the documentation.
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new ProcessException($"Creating user account is wrong. {string.Join(", ", result.Errors.Select(s => s.Description))}");

            // Returning the created user
            return mapper.Map<UserAccountModel>(user);
        }
    }

}

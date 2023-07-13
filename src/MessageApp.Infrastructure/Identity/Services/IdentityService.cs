using MessageApp.Application.Common.Contracts;
using MessageApp.Application.Common.Models.Authentication;
using MessageApp.Infrastructure.Identity.Entities;
using MessageApp.Infrastructure.Tenant;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenClaimService _tokenService;
        private readonly ITenantService _tenantService;
        public IdentityService(UserManager<User> userManager, RoleManager<Role> roleManager, ITokenClaimService tokenService, ITenantService tenantService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _tenantService = tenantService;
        }

        public async Task<UserDetailsResponse> GetUser()
        {
            var userEmail = _tenantService.GetTenantEmail();
            var user = await _userManager.FindByEmailAsync(userEmail);
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var userResponse = new UserDetailsResponse(user.Id, roleName, user.UserName, user.Email, false, null);
            return userResponse;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
                throw new Exception("Invalid Authentication");
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role.FirstOrDefault();
            var currentRole = await _roleManager.FindByNameAsync(roleName);
            var roleClaims = await _roleManager.GetClaimsAsync(currentRole);
            var currentClaims = roleClaims.Select(r => r.Value).ToList();
            var token = _tokenService.GetToken(user.Email, user.Id, roleName, currentClaims);
            var userResponse = new UserDetailsResponse(user.Id, roleName, user.UserName, user.Email, false, null);
            var loginResponse = new LoginResponse(token, userResponse);
            return loginResponse;
        }

        public async Task<LoginResponse> Register(RegisterRequest registerRequest)
        {
            if (registerRequest.Password == registerRequest.Password2)
            {
                var emailExists = await _userManager.FindByEmailAsync(registerRequest.Email);
                if (emailExists != null)
                {
                    throw new Exception("User with this email already exists");
                }
                var createUser = new User();
                createUser.UserName = registerRequest.Username;
                createUser.NormalizedUserName = registerRequest.Username.ToUpper();
                createUser.Email = registerRequest.Email;
                createUser.NormalizedEmail = registerRequest.Email.ToUpper();
                createUser.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(createUser);
                if (result.Succeeded)
                {
                    var passwordResult = await _userManager.AddPasswordAsync(createUser, registerRequest.Password);

                    if (passwordResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(createUser, "user");
                        var claims = new List<string>();
                        var token = _tokenService.GetToken(createUser.Email, createUser.Id, "user", claims);
                        var userResponse = new UserDetailsResponse(createUser.Id, "user", createUser.UserName, createUser.Email, true);
                        var loginResponse = new LoginResponse(token, userResponse);
                        return loginResponse;

                    }
                    else
                    {
                        throw new Exception("Not a valid password");

                    }


                }
                else
                {
                    throw new Exception("It wasn't possible to create the user try again later");

                }

            }
            else
            {
                throw new Exception("Passwords don't match");
            }
        }
    }
}

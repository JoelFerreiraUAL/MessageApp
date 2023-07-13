using MessageApp.Application.Common.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Contracts
{
    public interface IIdentityService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<UserDetailsResponse> GetUser();
        Task<LoginResponse> Register(RegisterRequest registerRequest);
    }
}

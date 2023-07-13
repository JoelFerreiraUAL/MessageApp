using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Contracts
{
    public interface ITokenClaimService
    {
        string GetToken(string email, int userId, string role, List<string>? currentClaims = null);
    }
}

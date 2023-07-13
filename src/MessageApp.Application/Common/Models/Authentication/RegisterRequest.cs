using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Models.Authentication
{
    public record RegisterRequest
   (
        string Username,
        string Email,
        string Password,
        string Password2
   );
}

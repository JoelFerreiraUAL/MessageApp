using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Models.Authentication
{
    public record UserDetailsResponse
    (
        int Id,
        string Role,
        string Username,
        string Email,
        bool FirstTimeLogin,
        string? PictureUrl = null
    );
}

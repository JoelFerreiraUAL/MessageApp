using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Models
{
    public record MessageModel
    (
       int Id,
       string Content,
       int UserId
    );
}

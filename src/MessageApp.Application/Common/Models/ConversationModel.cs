using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Models
{
    public record ConversationModel
    (
        int Id,
        string? GroupName,
        List<MessageModel>? Messages
    );
}

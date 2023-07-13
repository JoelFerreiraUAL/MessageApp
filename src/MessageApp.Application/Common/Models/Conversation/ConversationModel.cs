using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Application.Common.Models.Message;

namespace MessageApp.Application.Common.Models.Conversation
{
    public record ConversationModel
    (
        int Id,
        string? GroupName,
        List<MessageModel>? Messages
    );
}

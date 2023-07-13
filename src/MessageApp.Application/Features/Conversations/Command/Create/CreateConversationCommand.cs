using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Features.Conversations.Command.Create
{
    public record CreateConversationCommand
    (
     string? GroupName,
     List<int> UsersIds
    ) : IRequest;
}

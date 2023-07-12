using MediatR;
using MessageApp.Domain.Aggregates.ConversationAggregate;
using MessageApp.Domain.Aggregates.ConversationAggregate.Repository;
using MessageApp.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Features.Command.Create
{
    public class CreateConversationCommandHandler : IRequestHandler<CreateConversationCommand>
    {
        private readonly IConversationRepository _conversationRepository;
        public CreateConversationCommandHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }
        public async Task Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var usersIds = request.UsersIds.ConvertAll(UserId.Create).ToList();
            var conversation = Conversation.Create(request.GroupName, usersIds);
            await _conversationRepository.AddAsync(conversation);
        }
    }
}

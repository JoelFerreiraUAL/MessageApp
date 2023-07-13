using MediatR;
using MessageApp.Application.Common.Contracts;
using MessageApp.Domain.Aggregates.ConversationAggregate;
using MessageApp.Domain.Aggregates.ConversationAggregate.Repository;
using MessageApp.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Features.Conversations.Command.Create
{
    public class CreateConversationCommandHandler : IRequestHandler<CreateConversationCommand>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly ITenantService _tenantService;
        public CreateConversationCommandHandler(IConversationRepository conversationRepository,ITenantService tenantService)
        {
            _conversationRepository = conversationRepository;
            _tenantService = tenantService;
        }
        public async Task Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var currentUserId= UserId.Create(_tenantService.GetTenantId());
            var usersIds = request.UsersIds.ConvertAll(UserId.Create).ToList();
            usersIds.Add(currentUserId);
            var conversation = Conversation.Create(request.GroupName, usersIds);
            await _conversationRepository.AddAsync(conversation);
        }
    }
}

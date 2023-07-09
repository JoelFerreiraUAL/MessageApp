using MessageApp.Api.Domain.Aggregates.ConversationAggregate.Entities;
using MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Api.Domain.Common.Models;
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate
{
    public sealed class Conversation:BaseAudit
    {
        public ConversationId Id { get; private set; }
        private List<Message> _messages = new();
        private List<UserId> _userIds = new();
        public string GroupName { get; private set; }
        public IReadOnlyList<Message> Messages => _messages.AsReadOnly();
        public IReadOnlyList<UserId> UsersIds=> _userIds.AsReadOnly();

        private Conversation( string groupName)
        {
            GroupName = groupName;
        }
        public static  Conversation Create( string groupName)
        {
            return new Conversation(groupName);

        }
        private Conversation()
        {

        }
    }
}

using MessageApp.Api.Domain.Aggregates.ConversationAggregate.Entities;
using MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Api.Domain.Common.Models;
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate
{
    public sealed class Conversation: IBaseAudit
    {
        public ConversationId Id { get; private set; }
        private List<Message> _messages = new();
        private List<UserId> _userIds = new();
        public string GroupName { get; private set; }
        public IReadOnlyList<Message> Messages => _messages.AsReadOnly();
        public IReadOnlyList<UserId> UsersIds=> _userIds.AsReadOnly();

        public DateTime CreatedDate { get; set; }

        private Conversation( string groupName,List<Message>? messages=null)
        {
            GroupName = groupName;
            _messages = messages ?? new();
        }
        public static  Conversation Create( string groupName, List<Message>? messages = null)
        {
            return new Conversation(groupName,messages);

        }
        private Conversation()
        {

        }
    }
}

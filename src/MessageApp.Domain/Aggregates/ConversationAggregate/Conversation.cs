using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Domain.Aggregates.MessageAggregate;
using MessageApp.Domain.Aggregates.MessageAggregate.ValueObjects;
using MessageApp.Domain.Common.Models;
using MessageApp.Domain.Common.ValueObjects;

namespace MessageApp.Domain.Aggregates.ConversationAggregate
{
    public sealed class Conversation : IBaseAudit
    {
        public ConversationId Id { get; private set; }
        private List<MessageId> _messagesIds = new();
        private List<UserId> _userIds = new();
        public string GroupName { get; private set; }
        public IReadOnlyList<MessageId> MessagesIds => _messagesIds.AsReadOnly();
        public IReadOnlyList<UserId> UsersIds => _userIds.AsReadOnly();

        public DateTime CreatedDate { get; set; }

        private Conversation(string groupName, List<UserId>? userIds = null)
        {
            GroupName = groupName;
            _userIds = userIds ?? new();
        }
        public static Conversation Create(string groupName,List<UserId>? userIds=null)
        {
            return new Conversation(groupName, userIds);

        }
        private Conversation()
        {

        }
    }
}

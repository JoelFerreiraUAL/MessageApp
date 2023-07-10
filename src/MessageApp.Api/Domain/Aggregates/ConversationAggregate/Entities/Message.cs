using MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Api.Domain.Common.Models;
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate.Entities
{
    public sealed class Message: IBaseAudit
    {
        public MessageId Id { get; private set; }
        public string Content { get; private set; }
        public UserId UserId { get; private set; }
        public DateTime CreatedDate { get; set; }
        private Message(string content, UserId userId)
        {
            Content = content;
            UserId = userId;
        }
        public static Message Create(string content, UserId userId)
        {
            return new Message(content, userId);

        }
        private Message()
        {

        }
    }
}

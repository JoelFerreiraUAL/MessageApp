using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Domain.Aggregates.MessageAggregate.ValueObjects;
using MessageApp.Domain.Common.Models;
using MessageApp.Domain.Common.ValueObjects;

namespace MessageApp.Domain.Aggregates.MessageAggregate
{
    public sealed class Message : IBaseAudit
    {
        public MessageId Id { get; private set; }
        public ConversationId ConversationId { get; private set; }
        public string Content { get; private set; }
        public UserId UserId { get; private set; }
        public DateTime CreatedDate { get; set; }
        private Message(string content, UserId userId, ConversationId conversationId)
        {
            Content = content;
            UserId = userId;
            ConversationId = conversationId;
            CreatedDate = DateTime.Now;
        }
        public static Message Create(string content, UserId userId,ConversationId conversationId)
        {
            return new Message(content, userId,conversationId);

        }
        private Message()
        {

        }
    }
}

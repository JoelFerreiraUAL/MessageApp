
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects
{
    public sealed class ConversationId
    {
        public int Value { get; private set; }
        private ConversationId(int value)
        {
            Value = value;

        }
        public static ConversationId Create(int id)
        {
            return new ConversationId(id);

        }
        private ConversationId()
        {

        }
    }
}

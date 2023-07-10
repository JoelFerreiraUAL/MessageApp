
using MessageApp.Api.Domain.Common.Models;
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects
{
    public sealed class ConversationId : ValueObject
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

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        private ConversationId()
        {

        }
    }
}

using MessageApp.Domain.Common.Models;

namespace MessageApp.Domain.Aggregates.MessageAggregate.ValueObjects
{
    public sealed class MessageId : ValueObject
    {
        public int Value { get; private set; }
        private MessageId(int value)
        {
            Value = value;
        }
        public static MessageId Create(int value)
        {
            return new MessageId(value);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        private MessageId()
        {

        }
    }
}

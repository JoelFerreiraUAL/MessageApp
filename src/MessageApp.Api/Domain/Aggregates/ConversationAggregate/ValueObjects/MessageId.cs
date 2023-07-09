namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects
{
    public sealed class MessageId
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
        private MessageId()
        {

        }
    }
}



namespace MessageApp.Api.Domain.Common.ValueObjects
{
    public sealed class UserId
    {
        public int Value { get; private set; }
        private UserId(int value)
        {
            Value = value;

        }
        public static UserId Create( int id)
        {
            return new UserId(id);

        }
        private UserId()
        {

        }
    }
}

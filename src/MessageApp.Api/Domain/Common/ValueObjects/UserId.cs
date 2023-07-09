using MessageApp.Api.Domain.Common.Models;

namespace MessageApp.Api.Domain.Common.ValueObjects
{
    public sealed class UserId:BaseEntity<int>
    {
        private UserId(int id)
        {
            Id= id;

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

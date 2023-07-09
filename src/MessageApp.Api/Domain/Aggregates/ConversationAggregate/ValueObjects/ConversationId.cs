using MessageApp.Api.Domain.Common.Models;
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects
{
    public sealed class ConversationId:BaseEntity<int>
    {
        private ConversationId(int id)
        {
            Id = id;

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

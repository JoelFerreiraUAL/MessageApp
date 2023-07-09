using MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Api.Domain.Common.Interfaces;
using MessageApp.Api.Domain.Common.Models;
using MessageApp.Api.Domain.Common.ValueObjects;

namespace MessageApp.Api.Domain.Aggregates.ConversationAggregate
{
    public sealed class Conversation:IAggregateRoot
    {
        public ConversationId Id { get; private set; }
    }
}

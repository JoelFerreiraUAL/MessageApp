using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Domain.Aggregates.ConversationAggregate.Repository
{
    public interface IConversationRepository : IBaseRepository<Conversation, ConversationId>
    {
    }
}

using MessageApp.Domain.Aggregates.ConversationAggregate;
using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Repositories
{
    public interface IConversationRepository:IBaseRepository<Conversation,ConversationId>
    {
    }
}

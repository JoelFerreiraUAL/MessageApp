using Mapster;
using MessageApp.Application.Common.Models.Conversation;
using MessageApp.Domain.Aggregates.ConversationAggregate;
using MessageApp.Domain.Aggregates.MessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Mapping
{
    public class ConversationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Conversation conversation, Message message), ConversationModel>()
             .Map(dest => dest.Id, src => src.conversation.Id.Value);
        }
    }
}

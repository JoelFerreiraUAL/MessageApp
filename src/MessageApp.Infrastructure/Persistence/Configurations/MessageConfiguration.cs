using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Domain.Aggregates.MessageAggregate;
using MessageApp.Domain.Aggregates.MessageAggregate.ValueObjects;
using MessageApp.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.ToTable("Messages");
            builder.HasKey(c => c.Id);
            builder.Property(a => a.Id).HasConversion(o => o.Value, value => MessageId.Create(value)).ValueGeneratedOnAdd();
            builder.Property(a => a.UserId).HasConversion(o => o.Value, value => UserId.Create(value));
            builder.Property(a => a.ConversationId).HasConversion(o => o.Value, value => ConversationId.Create(value));
        }
    }
}

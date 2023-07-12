using MessageApp.Domain.Aggregates.ConversationAggregate;
using MessageApp.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Domain.Aggregates.MessageAggregate.ValueObjects;

namespace MessageApp.Infrastructure.Persistence.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            ConfigureConversationTable(builder);
            ConfigureConversationUsersIdsTable(builder);
            ConfigureConversationMessagesIdsTable(builder);
        }
        public void ConfigureConversationTable(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversations");
            builder.HasKey(c => c.Id);
            builder.Property(a => a.Id).HasConversion(o => o.Value, value => ConversationId.Create(value)).ValueGeneratedOnAdd();
        }
        public void ConfigureConversationUsersIdsTable(EntityTypeBuilder<Conversation> builder)
        {
            builder.OwnsMany(m => m.UsersIds, dib =>
            {
                dib.ToTable("ConversationUsersIds");

                dib.WithOwner().HasForeignKey("ConversationId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("UserId");

            });
            builder.Navigation(s => s.UsersIds).Metadata.SetField("_userIds");
            builder.Navigation(s => s.UsersIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
        public void ConfigureConversationMessagesIdsTable(EntityTypeBuilder<Conversation> builder)
        {
            builder.OwnsMany(m => m.MessagesIds, dib =>
            {
                dib.ToTable("ConversationMessagesIds");

                dib.WithOwner().HasForeignKey("ConversationId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("MessageId");

            });
            builder.Navigation(s => s.MessagesIds).Metadata.SetField("_messagesIds");
            builder.Navigation(s => s.MessagesIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

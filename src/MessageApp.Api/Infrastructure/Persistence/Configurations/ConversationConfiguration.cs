using MessageApp.Api.Domain.Aggregates.ConversationAggregate;
using MessageApp.Api.Domain.Aggregates.ConversationAggregate.Entities;
using MessageApp.Api.Domain.Aggregates.ConversationAggregate.ValueObjects;
using MessageApp.Api.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageApp.Api.Infrastructure.Persistence.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            ConfigureConversationTable(builder);
            ConfigureMessagesTable(builder);
            ConfigureConversationUsersTable(builder);
        }
        public void ConfigureConversationTable(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversations");
            builder.HasKey(c => c.Id);
            builder.Property(a => a.Id).HasConversion(o => o.Value, value => ConversationId.Create(value)).ValueGeneratedOnAdd();
        }
        public void ConfigureConversationUsersTable(EntityTypeBuilder<Conversation> builder)
        {
            builder.OwnsMany(m => m.UsersIds, dib =>
            {
                dib.ToTable("ConversationUsers");

                dib.WithOwner().HasForeignKey("ConversationId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("UserId");

            });
            builder.Navigation(s => s.UsersIds).Metadata.SetField("_userIds");
            builder.Navigation(s => s.UsersIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
        public void ConfigureMessagesTable(EntityTypeBuilder<Conversation> builder)
        {
            builder.OwnsMany(m => m.Messages, dib =>
            {
                dib.ToTable("Messages");
                dib.HasKey(c => c.Id);
                dib.Property(a => a.Id).HasConversion(o => o.Value, value => MessageId.Create(value)).ValueGeneratedOnAdd();
                dib.Property(a => a.UserId).HasConversion(o => o.Value, value => UserId.Create(value));
                dib.WithOwner().HasForeignKey("ConversationId");

            });

            builder.Metadata.FindNavigation(nameof(Conversation.Messages))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

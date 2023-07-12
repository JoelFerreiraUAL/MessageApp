
using MessageApp.Domain.Aggregates.ConversationAggregate;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Infrastructure.Persistence
{
    public class MessageAppDbContext : DbContext
    {
        public MessageAppDbContext(DbContextOptions<MessageAppDbContext> options) : base(options)
        {

        }
        public DbSet<Conversation> Conversations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageAppDbContext).Assembly);
        }
    }
}

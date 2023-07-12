using MessageApp.Domain.Aggregates.ConversationAggregate;
using MessageApp.Domain.Aggregates.ConversationAggregate.Repository;
using MessageApp.Domain.Aggregates.ConversationAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Persistence.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly MessageAppDbContext _context;
        public ConversationRepository(MessageAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Conversation entity)
        {
           await _context.AddRangeAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Conversation entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Conversation>> GetAllAsync()
        {
            return await _context.Conversations.AsNoTracking().ToListAsync();
        }

        public async Task<Conversation> GetByIdAsync(ConversationId id)
        {
            return await _context.Conversations.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Conversation entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

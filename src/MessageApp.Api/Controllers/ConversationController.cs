using MessageApp.Api.Domain.Aggregates.ConversationAggregate;
using MessageApp.Api.Domain.Aggregates.ConversationAggregate.Entities;
using MessageApp.Api.Domain.Common.ValueObjects;
using MessageApp.Api.Infrastructure.Persistence;
using MessageApp.Api.Requests.Conversation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly MessageAppDbContext _context;
        public ConversationController(MessageAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Conversations.AsNoTracking().ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateConversation(CreateConversationRequest createConversationRequest)
        {
            var conversation = Conversation.Create(createConversationRequest.GroupName, createConversationRequest.Messages.ConvertAll(c => Message.Create(c.Content, UserId.Create(c.userId))));
            await _context.Conversations.AddAsync(conversation);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

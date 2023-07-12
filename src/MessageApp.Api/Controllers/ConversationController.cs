using MessageApp.Contracts.Requests.Conversation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        public ConversationController()
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateConversation(CreateConversationRequest createConversationRequest)
        {
            //var conversation = Conversation.Create(createConversationRequest.GroupName, createConversationRequest.Messages.ConvertAll(c => Message.Create(c.Content, UserId.Create(c.userId))));
            //await _context.Conversations.AddAsync(conversation);
            //await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

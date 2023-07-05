using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMessage>>> GetMessages()
        {
            return await _messageService.GetMessages();
        }

        [HttpPost]
        [Route("CreateMessage")]
        public async Task<ActionResult<TblMessage>> PostMessage(TblMessage tblMessage)
        {
            return await _messageService.PostMessage(tblMessage);

        }

        [HttpGet]
        [Route("GetTopMessages")]

        public async Task<ActionResult<IEnumerable<TblMessage>>> GetTopMessages()
        {
            return await _messageService.GetTopMessages();
        }

        [HttpGet]
        [Route("MessagesByUserId")]

        public async Task<ActionResult<List<TblMessage>>> GetMessagesByUserId(int SenderId)
        {
            return await _messageService.GetMessagesByUserId(SenderId);
        }
    }
}
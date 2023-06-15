using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class MessageService : IMessageService
    {
        private readonly ToDoListDbContext _context;

        public MessageService(ToDoListDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<TblMessage>>> GetMessages()
        {
            var messages = await _context.TblMessages
                .Select(c => new MessageDto
                {
                    MessageId = c.MessageId,
                    SenderId = c.SenderId,
                    ReceiverId = c.ReceiverId,
                    Subject = c.Subject,
                    Body = c.Body,
                    Timestamp = c.Timestamp
                })
                .ToListAsync();
            return new OkObjectResult(messages);
        }

        public async Task<ActionResult<TblMessage>> PostMessage(TblMessage tblMessage)
        {
            if (!TblUserExists(tblMessage.ReceiverId))
            {
                return new BadRequestObjectResult("User doesn't exist");
            }
            else
            {
                _context.TblMessages.Add(tblMessage);
                await _context.SaveChangesAsync();

                return new CreatedAtActionResult("Post", "TblMessage", new { id = tblMessage.MessageId }, tblMessage);

            }
            bool TblUserExists(int receiverid)
            {
                return _context.TblMessages.Any(e => e.ReceiverId == receiverid);
            }
        }
    }


}



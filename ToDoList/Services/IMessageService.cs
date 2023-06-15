using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IMessageService
    {
        public Task<ActionResult<IEnumerable<TblMessage>>> GetMessages();
        public Task<ActionResult<TblMessage>> PostMessage(TblMessage tblMessage);

    }
    
}

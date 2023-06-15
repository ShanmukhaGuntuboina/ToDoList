using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TblMessage
{
    public int MessageId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual TblUser Receiver { get; set; } = null!;

    public virtual TblUser Sender { get; set; } = null!;
}

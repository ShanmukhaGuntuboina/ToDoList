using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TblLog
{
    public int LoggerId { get; set; }

    public int UserId { get; set; }

    public string Activity { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}

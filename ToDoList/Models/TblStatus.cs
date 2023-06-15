using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TblStatus
{
    public int StatusId { get; set; }

    public string StatusType { get; set; } = null!;

    public virtual ICollection<TblTask> TblTasks { get; set; } = new List<TblTask>();
}

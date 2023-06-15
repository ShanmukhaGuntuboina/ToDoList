using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TblTask
{
    public int TaskId { get; set; }

    public string TaskType { get; set; } = null!;

    public string TaskName { get; set; } = null!;

    public int CreatedByUser { get; set; }

    public int AssignedToUser { get; set; }

    public DateTime TaskDueDate { get; set; }

    public int StatusId { get; set; }

    public virtual TblUser AssignedToUserNavigation { get; set; } = null!;

    public virtual TblUser CreatedByUserNavigation { get; set; } = null!;

    public virtual TblStatus Status { get; set; } = null!;
}

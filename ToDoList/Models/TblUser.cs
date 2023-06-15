using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserTypeId { get; set; }

    public virtual ICollection<TblLog> TblLogs { get; set; } = new List<TblLog>();

    public virtual ICollection<TblMessage> TblMessageReceivers { get; set; } = new List<TblMessage>();

    public virtual ICollection<TblMessage> TblMessageSenders { get; set; } = new List<TblMessage>();

    public virtual ICollection<TblTask> TblTaskAssignedToUserNavigations { get; set; } = new List<TblTask>();

    public virtual ICollection<TblTask> TblTaskCreatedByUserNavigations { get; set; } = new List<TblTask>();

    public virtual TblUserType UserType { get; set; } = null!;
}

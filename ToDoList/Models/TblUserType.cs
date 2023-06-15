using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class TblUserType
{
    public int UserTypeId { get; set; }

    public string UserType { get; set; } = null!;

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}

namespace ToDoList.Models
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int UserTypeId { get; set; }
    }
}

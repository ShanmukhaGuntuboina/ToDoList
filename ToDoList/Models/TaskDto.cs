namespace ToDoList.Models
{
    public class TaskDto
    {
        public int TaskId { get; set; }

        public string TaskType { get; set; } = null!;

        public string TaskName { get; set; } = null!;

        public int CreatedByUser { get; set; }

        public int AssignedToUser { get; set; }

        public DateTime TaskDueDate { get; set; }

    }
}

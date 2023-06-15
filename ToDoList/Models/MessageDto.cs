namespace ToDoList.Models
{
    public class MessageDto
    {
        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string Subject { get; set; } = null!;

        public string Body { get; set; } = null!;

        public DateTime Timestamp { get; set; }

    }
}

namespace TicketingSystem.Data.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Body { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

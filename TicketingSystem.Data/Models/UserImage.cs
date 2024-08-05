namespace TicketingSystem.Data.Models;

public class UserImage
{
    public Guid ImgId { get; set; }
    public string Path { get; set; }
    public User User { get; set; }
}

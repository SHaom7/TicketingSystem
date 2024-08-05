using TicketingSystem.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace TicketingSystem.Data.Dtos
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateOnly Birthday { get; set; }
        public string Address { get; set; }
        public UserStatus UserStatus { get; set; }
        public string ImgPath { get; set; } //within the service create a an imgusre using the path
    }
}

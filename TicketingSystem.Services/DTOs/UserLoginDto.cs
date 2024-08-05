using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Data.Dtos
{
    public class UserLoginDto
    {
        //How to indicate username or email?
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

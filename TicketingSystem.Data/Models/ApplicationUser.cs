using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserImage { get; set; }
        public DateOnly DateOfBirth { get; set; }


    }
}

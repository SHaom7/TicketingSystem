using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasOne(x => x.UserImage).WithOne(c => c.User).HasForeignKey<UserImage>(c => c.ImgId);

            modelBuilder.Entity<Ticket>().
                HasOne(x => x.Product).WithMany(c => c.Tickets).HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Ticket>().
                HasOne(x => x.User).WithMany().HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Ticket>().
                HasOne(x => x.User).WithMany().HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<Attachment>().
                HasOne(x => x.Ticket).WithMany(c => c.Attachments).HasForeignKey(c => c.TicketId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Ticket).WithMany(t => t.Comments).HasForeignKey(c => c.TicketId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId);

        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Tourist_Platform.Models
{
    public class TouristDbContext :DbContext
    {
        public TouristDbContext(DbContextOptions<TouristDbContext> options) : base(options) 
        {
        }

        public DbSet<AdminLogic> AdminLogics { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<ThayHuan> ThayHuans { get; set;}

    }
}

using Microsoft.EntityFrameworkCore;
using EventPopper.Models;

namespace EventPopper.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<EventPopper.Models.Event> Event { get; set; }
        public DbSet<EventPopper.Models.Comment> Comment { get; set; }
        public DbSet<EventPopper.Models.Coupon> Coupon { get; set; }
    }
}
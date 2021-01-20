using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Order.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Orders> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models.Domain;

namespace WebAppAPI.Data
    
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Posts> Posts { get; set; }
    }
}

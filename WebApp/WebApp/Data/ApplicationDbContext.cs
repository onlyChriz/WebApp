using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models.Domain;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext //CHANGED FROM IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<BlogPosts> BlogPosts { get; set; }

    }
}
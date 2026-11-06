using Microsoft.EntityFrameworkCore;
using Shared.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shared.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        [Key]
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
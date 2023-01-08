using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Task = HouseholdManager.Models.Task;

namespace HouseholdManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }


    }
}

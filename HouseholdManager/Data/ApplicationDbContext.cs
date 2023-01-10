using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Mission = HouseholdManager.Models.Mission;

namespace HouseholdManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Contributor> Contributors { get; set; }


    }
}

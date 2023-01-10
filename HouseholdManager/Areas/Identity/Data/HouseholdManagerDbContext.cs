using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Data;

public class HouseholdManagerDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Contributor> Contributors { get; set; }

    public HouseholdManagerDbContext(DbContextOptions<HouseholdManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

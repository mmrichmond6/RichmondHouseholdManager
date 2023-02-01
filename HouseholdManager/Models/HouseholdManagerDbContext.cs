using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HouseholdManager.Models;

public class HouseholdManagerDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Contributor> Contributors { get; set; }

    public DbSet<Household> Households { get; set; }

    public DbSet<AppUser> AppUsers { get; set; }

    public HouseholdManagerDbContext(DbContextOptions<HouseholdManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedHousehold(builder);
        SeedRoles(builder);
        SeedUsers(builder);
        SeedUserRoles(builder);
        SeedUserContributor(builder);
        SeedRoom(builder);
        SeedMission(builder);
    }

    private static void SeedHousehold(ModelBuilder builder)
    {
        Household households = new Household()
        {
            HouseholdId = 1,
            HouseholdName = "DefaultHousehold",
            HouseholdIcon = "🏠"
        };

        builder.Entity<Household>().HasData(households);
    }
    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "Administrator" },
            new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
    }

    private static void SeedUsers(ModelBuilder builder)
    {
        PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
        AppUser user = new AppUser();

        AppUser appAdmin = new AppUser()
        {
            Id = "a1addd14-6340-4840-95c2-db12554843e5",
            FirstName = "DefaultAdmin1",
            LastName = "DefaultAdmin1",
            Age = 30,
            UserName = "defaultAdmin1@yahoo.com",
            NormalizedUserName = "DEFAULTADMIN@YAHOO.COM",
            Email = "defaultAdmin1@yahoo.com",
            NormalizedEmail = "DEFAULTADMIN1@YAHOO.COM",
            PasswordHash = passwordHasher.HashPassword(user, "Coder77@1"),
            EmailConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            PhoneNumber = "111-222-3333",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true
        };
        builder.Entity<AppUser>().HasData(appAdmin);

        AppUser appUser = new AppUser()
        {
            Id = "u1ua87c6-b718-4f48-90a2-458e0a2443e6",
            FirstName = "DefaultUser",
            LastName = "DefaultUser",
            Age = 15,
            UserName = "defaultUser@yahoo.com",
            NormalizedUserName = "DEFAULTUSER@YAHOO.COM",
            Email = "defaultUser@yahoo.com",
            NormalizedEmail = "DEFAULTUSER@YAHOO.COM",
            PasswordHash = passwordHasher.HashPassword(user, "Coder77@1"),
            EmailConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            PhoneNumber = "111-222-3333",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true
        };
        builder.Entity<AppUser>().HasData(appUser);
    }

    private static void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { UserId = "a1addd14-6340-4840-95c2-db12554843e5", RoleId = "fab4fac1-c546-41de-aebc-a14da6895711" },
            new IdentityUserRole<string>() { UserId = "a1addd14-6340-4840-95c2-db12554843e5", RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330" },
            new IdentityUserRole<string>() { UserId = "u1ua87c6-b718-4f48-90a2-458e0a2443e6", RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330" });
    }

    private static void SeedUserContributor(ModelBuilder builder)
    {
        Contributor contributor1 = new Contributor() { ContributorId = 1,ContributorType = "Admin",HouseholdId= 1,UserName="defaultAdmin@yahoo.com",ContributorIcon = "👩‍🔧"};
        builder.Entity<Contributor>().HasData(contributor1);
        Contributor contributor2 = new Contributor() { ContributorId = 2, ContributorType = "Contributor", HouseholdId = 1, UserName = "defaultUser@yahoo.com", ContributorIcon = "👩‍💼" };
        builder.Entity<Contributor>().HasData(contributor2);
    }

    private static void SeedRoom(ModelBuilder builder)
    {
        Room room1 = new Room() { RoomId = 1,RoomName = "Kitchen",RoomIcon = "🥄"};
        builder.Entity<Room>().HasData(room1);
        Room room2 = new Room() { RoomId = 2,RoomName = "Bathroom",RoomIcon = "🧻" };
        builder.Entity<Room>().HasData(room2);
        Room room3 = new Room() { RoomId = 3,RoomName = "Master Bedroom",RoomIcon = "🛏"};
        builder.Entity<Room>().HasData(room3);
        Room room4 = new Room() { RoomId = 4,RoomName = "Living Room", RoomIcon = "🛋" };
        builder.Entity<Room>().HasData(room4);
        Room room5 = new Room() { RoomId = 5,RoomName = "Bedroom", RoomIcon = "🛏" };
        builder.Entity<Room>().HasData(room5);
        Room room6 = new Room() { RoomId = 6,RoomName = "Guest Bedroom", RoomIcon = "🛏" };
        builder.Entity<Room>().HasData(room6);
        Room room7 = new Room() { RoomId = 7,RoomName = "Master Bathroom", RoomIcon = "🧻" };
        builder.Entity<Room>().HasData(room7);
        Room room8 = new Room() { RoomId = 8,RoomName = "Dining Room", RoomIcon = "🍽" };
        builder.Entity<Room>().HasData(room8);
        Room room9 = new Room() { RoomId = 9,RoomName = "Yard", RoomIcon = "🌳" };
        builder.Entity<Room>().HasData(room9);
    }

    private static void SeedMission(ModelBuilder builder)
    {
        Mission mission1 = new Mission() { MissionId = 1, MissionName = "Wash dishes", MissionIcon = "🍴", MissionStatus = "ToDo", MissionPoints = 2, MissionDate = DateTime.Now, RoomId = 1, ContributorId = 2, };
        builder.Entity<Mission>().HasData(mission1);
        Mission mission2 = new Mission() { MissionId = 2, MissionName = "Make bed", MissionIcon = "🛏", MissionStatus = "ToDo", MissionPoints = 1, MissionDate = DateTime.Now, RoomId = 5, ContributorId = 1, };
        builder.Entity<Mission>().HasData(mission2);
        Mission mission3 = new Mission() { MissionId = 3, MissionName = "Make bed", MissionIcon = "🛏", MissionStatus = "ToDo", MissionPoints = 1, MissionDate = DateTime.Now, RoomId = 3, ContributorId = 2, };
        builder.Entity<Mission>().HasData(mission3);
        Mission mission4 = new Mission() { MissionId = 4, MissionName = "Mow lawn", MissionIcon = "✂", MissionStatus = "ToDo", MissionPoints = 5, MissionDate = DateTime.Now, RoomId = 9, ContributorId = 1, };
        builder.Entity<Mission>().HasData(mission4);
        Mission mission5 = new Mission() { MissionId = 5, MissionName = "Make dinner", MissionIcon = "🍗", MissionStatus = "ToDo", MissionPoints = 4, MissionDate = DateTime.Now, RoomId = 1, ContributorId = 1, };
        builder.Entity<Mission>().HasData(mission5);
    }

}
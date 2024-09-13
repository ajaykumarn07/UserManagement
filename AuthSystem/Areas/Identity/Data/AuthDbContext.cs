using AuthSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Models;

namespace AuthSystem.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserList> UserLists { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for table

        modelBuilder.Entity<UserList>().HasData(new UserList
        {
            Id = 1,
            FirstName = "Ajay",
            MiddleName = "",
            LastName = "Kumar N",
            Email = "ajay@gmail.com",
            PhoneNumber = 8767674523,
            Address = "WhiteField",
            City = "Bengaluru",
            State = "Karnataka",
            Pincode = 560067,
            UserName = "ajayn",
            Password = "Ajay@6527",
            Status = "Active"
        },
        new UserList
        {
            Id = 2,
            FirstName = "Ashish",
            MiddleName = "",
            LastName = "Sherugar",
            Email = "Ashish@gmail.com",
            PhoneNumber = 9767674523,
            Address = "Halasuru",
            City = "Bengaluru",
            State = "Karnataka",
            Pincode = 560001,
            UserName = "ashish",
            Password = "Ashish@6527",
            Status = "Active"
        });
    }
}

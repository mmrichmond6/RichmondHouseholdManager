using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class AppUser : IdentityUser
    {

        public string? FirstName { get; set; }


        public string? LastName { get; set; }

        public int? Age { get; set; }
    }
}

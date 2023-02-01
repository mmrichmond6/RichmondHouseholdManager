using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HouseholdManager.Models
{
    public class Contributor
    {
        [Key]
        public int ContributorId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Contributor type (Administrator or Contributor) is required.")]
        public string ContributorType { get; set; } = "Contributor";

        [Column(TypeName = "nvarchar(50)")]
        public string? ContributorIcon { get; set; } = "";

        //HouseholdId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select household")]
        public int HouseholdId { get; set; }

        public Household? Household { get; set; }

        public string UserName { get; set; }

        public AppUser? User { get; set; }


        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return Household == null ? "" : Household.HouseholdIcon + " " + Household.HouseholdName;
            }
        }

        [NotMapped]
        public string? ContributorUserNameWithIcon
        {
            get
            {
                return this.ContributorIcon + " " + this.UserName;
            }
        }
    }    
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Contributor
    {
        [Key]
        public int ContributorId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Contributor Name is required.")]
        public string ContributorName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Contributor type (Administrator or Contributor) is required.")]
        public string ContributorType { get; set; } = "Contributor";

        [DataType(DataType.EmailAddress)]
        public string? ContributorEmail { get; set; } = "xxxxx@xxxx.com";

        [Column(TypeName = "nvarchar(50)")]
        public string ContributorIcon { get; set; } = "";

        //HouseholdId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select room(s)")]
        public int HouseholdId { get; set; }

        public Household? Household { get; set; }

        [NotMapped]
        public string? ContributorNameWithIcon
        {
            get
            {
                return this.ContributorIcon + " " + this.ContributorName;
            }
        }

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return Household == null ? "" : Household.HouseholdIcon + " " + Household.HouseholdName;
            }
        }
    }    
}

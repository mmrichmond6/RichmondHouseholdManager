using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Contributor
    {
        [Key]
        public int ContributorId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Contributor Name is required.")]
        public string ContributorName { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [Required(ErrorMessage = "Contributor type (Administrator or Contributor) is required.")]
        public string ContributorType { get; set; } = "Contributor";

        [DataType(DataType.EmailAddress)]
        public string? ContributorEmail { get; set; } = "xxxxx@xxxx.com";

        [Column(TypeName = "nvarchar(5)")]
        public string ContributorIcon { get; set; } = "";

        [NotMapped]
        public string? ContributorNameWithIcon
        {
            get
            {
                return this.ContributorIcon + " " + this.ContributorName;
            }
        }

    }
}

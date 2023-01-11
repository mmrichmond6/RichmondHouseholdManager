using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManager.Models
{
    public class Household
    {
        [Key]
        public int HouseholdId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Household name is required.")]
        public string HouseholdName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string HouseholdIcon { get; set; } = "";

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select room(s)")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        //ContributorId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select contributor(s)")]
        public int ContributorId { get; set; }

        public Contributor? Contributor { get; set; }

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return this.HouseholdIcon + " " + this.HouseholdName;
            }
        }

        [NotMapped]
        public string? RoomNameWithIcon
        {
            get
            {
                return Room == null ? "" : Room.RoomIcon + " " + Room.RoomName;
            }
        }

        [NotMapped]
        public string? ContributorNameWithIcon
        {
            get
            {
                return Contributor == null ? "" : Contributor.ContributorIcon + " " + Contributor.ContributorName;
            }
        }

    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;

namespace HouseholdManager.Models
{
    public class Mission
    {
        [Key]
        public int MissionId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Name of mission is required.")]
        public string MissionName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MissionIcon { get; set; } = "";

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        //ContributorId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int ContributorId { get; set; }

        public Contributor? Contributor { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        public int MissionPoints { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? MissionInstructions { get; set; }

        public DateTime MissionDate { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(50)")]
        public string MissionStatus { get; set; } = "ToDo";

        [NotMapped]
        public string? MissionNameWithIcon
        {
            get
            {
                return this.MissionIcon + " " + this.MissionName;
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

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HouseholdManager.Models;

namespace HouseholdManager.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Name of task is required.")]
        public string TaskName { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string TaskIcon { get; set; } = "";

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        //UserId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int UserId { get; set; }

        public User? User { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        public int Points { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Instructions { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? TaskNameWithIcon
        {
            get
            {
                return this.TaskIcon + " " + this.TaskName;
            }
        }
    }
}

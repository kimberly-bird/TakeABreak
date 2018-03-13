using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeABreak.Models
{
    public class Day
    {
        [Key]
        public int DayId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public int PointsGoal { get; set; }

        public int? PointsEarned { get; set; }

        public int? ProductivityRating { get; set; }

        public string Reminders { get; set; }

        public virtual ICollection<Break> Breaks { get; set; }

        public Day()
        {
            PointsEarned = 0;
        }
    }
}

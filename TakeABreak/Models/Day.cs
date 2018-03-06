﻿using System;
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
        public DateTime Date { get; set; }

        [Required]
        public int PointsGoal { get; set; }

        [Required]
        public int ProductivityRating { get; set; }

        public string Reminders { get; set; }

        public virtual ICollection<Break> Breaks { get; set; }
    }
}

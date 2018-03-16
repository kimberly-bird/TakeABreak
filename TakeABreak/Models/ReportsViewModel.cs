using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeABreak.Models
{
    public class ReportsViewModel
    {
        // user
        public string Email { get; set; }

        // Day model
        public int DayId { get; set; }
        public DateTime Date { get; set; }
        public int PointsGoal { get; set; }
        public int PointsEarned { get; set; }
        public int ProductivityRating { get; set; }
        public string Reminders { get; set; }

        // Break model
        public int BreakId { get; set; }
        public DateTime Time { get; set; }
        public int Length { get; set; }

        // BreakType model
        public int BreakTypeId { get; set; }
        public string Type { get; set; }
        public int PointValue { get; set; }

    }
}

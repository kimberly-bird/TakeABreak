using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeABreak.Models
{
    public class DashboardViewModel
    {
        // Day model
        public DateTime Date { get; set; }
        public int PointsGoal { get; set; }
        public int ProductivityRating { get; set; }
        public string Reminders { get; set; }

        // Break model
        public DateTime Time { get; set; }
        public int Length { get; set; }

        // BreakType model
        public string Type { get; set; }
        public int PointValue { get; set; }
    }
}

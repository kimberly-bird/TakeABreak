using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeABreak.Models
{
    public class Break
    {
        [Key]
        public int BreakId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public int DayId { get; set; }
        public Day Day { get; set; }

        [Required]
        public int BreakTypeId { get; set; }
        public BreakType BreakType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeABreak.Models
{
    public class BreakType
    {
        [Key]
        public int BreakTypeId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int PointValue { get; set; }

        public virtual ICollection<Break> Breaks { get; set; }
    }
}

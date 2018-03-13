using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeABreak.Models
{
    public class ProductivityRatingViewModel
    {
        public int? ProductivityRating { get; set; }

        public List<SelectListItem> ProductivityRatings { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Unrated" },
            new SelectListItem { Value = "1", Text = "1" },
            new SelectListItem { Value = "2", Text = "2" },
            new SelectListItem { Value = "3", Text = "3" },
            new SelectListItem { Value = "4", Text = "4" },
            new SelectListItem { Value = "5", Text = "5" }
        };
    }
}

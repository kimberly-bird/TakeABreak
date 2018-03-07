using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeABreak.Data;
using TakeABreak.Models;

namespace TakeABreak.ViewComponents
{
    public class DayDetailViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public DayDetailViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        
        private async Task<Day> GetItemsAsync()
        {
            var day = await _context.Day
                .OrderByDescending(d => d.Date)
                .FirstAsync();

            return day;
        }
    }
}

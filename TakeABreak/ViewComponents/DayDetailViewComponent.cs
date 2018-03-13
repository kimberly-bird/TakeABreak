using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeABreak.Data;
using TakeABreak.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace TakeABreak.ViewComponents
{
    public class DayDetailViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DayDetailViewComponent(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // This task retrieves the currently authenticated user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private async Task<Day> GetItemsAsync()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var day = await _context.Day
                .Where(u => u.User == user)
                .OrderByDescending(d => d.Date)
                .FirstOrDefaultAsync();
           
            return day;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeABreak.Data;
using TakeABreak.Models;

namespace TakeABreak.ViewComponents
{
    public class ReportsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportsViewComponent(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        private async Task<List<ReportsViewModel>> GetItemsAsync()
        {
            // get current user
            ApplicationUser user = await GetCurrentUserAsync();

            // get last 5 days where productivity rating is greater than 0
            var productiveDay = await _context.Day
                .Where(u => u.User == user)
                .Where(p => p.ProductivityRating > 0)
                .OrderByDescending(d => d.Date)
                .Take(5)
                .ToListAsync();

            // list of reportviewmodels
            List<ReportsViewModel> productiveReports = new List<ReportsViewModel>();
           
            foreach (var prodDay in productiveDay)
            {
                // new report instance
                ReportsViewModel newReport = new ReportsViewModel
                {
                    // add properties to new report
                    ProductivityRating = (int)prodDay.ProductivityRating,
                    Date = prodDay.Date,
                    PointsEarned = (int)prodDay.PointsEarned,
                    PointsGoal = (int)prodDay.PointsGoal
                };
                productiveReports.Add(newReport);
            }
            return productiveReports;
        }

    }
}

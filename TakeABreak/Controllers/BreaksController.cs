using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TakeABreak.Data;
using TakeABreak.Models;

namespace TakeABreak.Controllers
{
    public class BreaksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BreakType _breakType;
        private readonly UserManager<ApplicationUser> _userManager;

        public BreaksController(ApplicationDbContext context, BreakType breakType, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _breakType = breakType;
            _userManager = userManager;
        }

        // This task retrieves the currently authenticated user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Breaks
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Break.Include(b => b.BreakType).Include(d => d.Day);
            return View(await applicationDbContext
                .Where(u => u.Day.User == user)
                .ToListAsync());
        }

        // GET: Breaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @break = await _context.Break
                .Include(b => b.BreakType)
                .Include(d => d.Day)
                .SingleOrDefaultAsync(m => m.BreakId == id);
            if (@break == null)
            {
                return NotFound();
            }

            return View(@break);
        }

        // GET: Breaks/Create
        public IActionResult Create()
        {
            ViewData["BreakTypeId"] = new SelectList(_context.BreakType, "BreakTypeId", "Type");
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "UserId");
            return View();
        }

        // POST: Breaks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreakId,Time,Length,DayId,BreakTypeId")] Break @break)
        {
            if (ModelState.IsValid)
            {
                // get current DayId
                @break.DayId = _context.Day
                .OrderByDescending(d => d.Date)
                .First().DayId;
                
                // get day object
                var currentDaysPoints = _context.Day
                .OrderByDescending(d => d.Date)
                .First();

                // get selected break type
                var selectedBreakType = _context.BreakType.SingleOrDefault(b => b.BreakTypeId == @break.BreakTypeId);

                // calculate points earned for break
                var pointsEarned = selectedBreakType.PointValue * @break.Length;

                // add points to Day.PointsEarned property
                currentDaysPoints.PointsEarned += pointsEarned;
                
                // add break
                _context.Add(@break);
                _context.Update(currentDaysPoints);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreakTypeId"] = new SelectList(_context.BreakType, "BreakTypeId", "Type", @break.BreakTypeId);
            return RedirectToAction(nameof(HomeController.About), "Home");
        }

        // GET: Breaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @break = await _context.Break.SingleOrDefaultAsync(m => m.BreakId == id);
            if (@break == null)
            {
                return NotFound();
            }
            ViewData["BreakTypeId"] = new SelectList(_context.BreakType, "BreakTypeId", "Type", @break.BreakTypeId);
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "UserId", @break.DayId);
            return View(@break);
        }

        // POST: Breaks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BreakId,Time,Length,DayId,BreakTypeId")] Break @break)
        {
            if (id != @break.BreakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@break);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakExists(@break.BreakId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreakTypeId"] = new SelectList(_context.BreakType, "BreakTypeId", "Type", @break.BreakTypeId);
            ViewData["DayId"] = new SelectList(_context.Day, "DayId", "UserId", @break.DayId);
            return View(@break);
        }

        // GET: Breaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @break = await _context.Break
                .Include(b => b.BreakType)
                .Include(d => d.Day)
                .SingleOrDefaultAsync(m => m.BreakId == id);
            if (@break == null)
            {
                return NotFound();
            }

            return View(@break);
        }

        // POST: Breaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @break = await _context.Break.SingleOrDefaultAsync(m => m.BreakId == id);
            _context.Break.Remove(@break);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakExists(int id)
        {
            return _context.Break.Any(e => e.BreakId == id);
        }
    }
}

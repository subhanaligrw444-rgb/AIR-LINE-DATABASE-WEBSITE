using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class CrewDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrewDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /CrewDetails/Index
        public async Task<IActionResult> Index()
        {
            var crewDetails = await _context.CrewDetails
                .Include(c => c.Flight)
                .Include(c => c.Staff)
                .ToListAsync();

            ViewBag.Flights = await _context.Flights.ToListAsync();
            ViewBag.Staffs  = await _context.Staffs.ToListAsync();

            return View(crewDetails);
        }

        // POST: /CrewDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Flight_ID,Staff_ID,Role,Shift")] CrewDetails crewDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crewDetails);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Crew member assigned successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to assign crew. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /CrewDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var crewDetails = await _context.CrewDetails.FindAsync(id);
            if (crewDetails != null)
            {
                _context.CrewDetails.Remove(crewDetails);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Crew assignment removed successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

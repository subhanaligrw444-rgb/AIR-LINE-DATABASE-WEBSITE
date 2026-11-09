using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class AircraftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AircraftController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Aircraft/Index
        public async Task<IActionResult> Index()
        {
            var aircrafts = await _context.Aircrafts.ToListAsync();
            return View(aircrafts);
        }

        // POST: /Aircraft/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Capacity,Regrestration_No")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraft);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Aircraft added successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to add aircraft. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Aircraft/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft != null)
            {
                _context.Aircrafts.Remove(aircraft);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Aircraft deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

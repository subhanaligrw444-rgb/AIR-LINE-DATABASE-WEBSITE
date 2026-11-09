using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class AirportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Airport/Index
        public async Task<IActionResult> Index()
        {
            // AsNoTracking avoids EF tracking conflicts on navigation properties
            var airports = await _context.Airports
                .AsNoTracking()
                .ToListAsync();

            return View(airports);
        }

        // POST: /Airport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Country_Name,City,IATA_Code")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airport);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Airport added successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to add airport. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Airport/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport != null)
            {
                _context.Airports.Remove(airport);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Airport deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

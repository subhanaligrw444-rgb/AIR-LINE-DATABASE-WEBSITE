using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Flight/Index
        public async Task<IActionResult> Index()
        {
            var flights = await _context.Flights
                .Include(f => f.OriginAirport)
                .Include(f => f.DestinationAirport)
                .Include(f => f.Aircraft)
                .ToListAsync();

            ViewBag.Airports  = await _context.Airports.ToListAsync();
            ViewBag.Aircrafts = await _context.Aircrafts.ToListAsync();

            return View(flights);
        }

        // POST: /Flight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Flight_No,Origin_ID,Dest_ID,Aircraft_ID,Arr_Time,Dep_Time,Status")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Flight scheduled successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to schedule flight. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Flight/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Flight deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassengerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Passenger/Index
        public async Task<IActionResult> Index()
        {
            var passengers = await _context.Passengers.ToListAsync();
            return View(passengers);
        }

        // POST: /Passenger/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone_No,Passport_No,Nationality")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Passenger registered successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to register passenger. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Passenger/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Passenger deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

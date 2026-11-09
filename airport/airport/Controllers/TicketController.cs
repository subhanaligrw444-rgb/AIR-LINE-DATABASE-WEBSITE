using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Ticket/Index
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Flight)
                .Include(t => t.Passenger)
                .ToListAsync();

            ViewBag.Flights    = await _context.Flights.ToListAsync();
            ViewBag.Passengers = await _context.Passengers.ToListAsync();

            return View(tickets);
        }

        // POST: /Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Flight_ID,Passenger_ID,Class,Seat_No,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Ticket booked successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to book ticket. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Ticket/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Ticket deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

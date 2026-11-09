using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airline_system.Data;
using airline_system.Models;

namespace airline_system.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Staff/Index
        public async Task<IActionResult> Index()
        {
            var staff = await _context.Staffs.ToListAsync();
            return View(staff);
        }

        // POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone_No,Email,Role")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Staff member added successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to add staff. Please fill all fields correctly.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Staff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Staff member deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

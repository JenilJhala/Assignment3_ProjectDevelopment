using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallUsedCars_WebApp.Database;
using SmallUsedCars_WebApp.Models;

namespace SmallUsedCars_WebApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VehicleController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> List() => View(await _context.Vehicles.ToListAsync());
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }
    }
}

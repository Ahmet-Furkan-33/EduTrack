using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEduApp.DataClass;
using StudentEduProject.DataClass;

namespace StudentEduProject.Controllers
{
    public class PerformansController : Controller
    {
        private readonly DataContext _context;

        public PerformansController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
          return View(await _context.Performanslar.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Performans model)
        {      
            _context.Performanslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performans = await _context.Performanslar.FindAsync(id);
            if (performans == null)
            {
                return NotFound();
            }

            return View(performans);
        }

      
        
    }
}
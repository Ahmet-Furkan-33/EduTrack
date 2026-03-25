using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEduApp.DataClass;
using StudentEduProject.DataClass;

namespace StudentEduProject.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
          return View(await _context.Ogrenciler.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {      
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var ogrenci = await _context.Ogrenciler
            .Include(o => o.EgitimKayitlari)
            .ThenInclude(o =>o.EgitimModul)
            .FirstOrDefaultAsync(o =>o.Id == id);
            if(ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
            
        }
        [HttpPost]
        public async Task<IActionResult>Delete([FromForm]int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}
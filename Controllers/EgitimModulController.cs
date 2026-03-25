using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using StudentEduProject.DataClass;

namespace StudentEducationProject.Controllers
{
    public class EgitimModulController : Controller
    {
        private readonly DataContext _context;

        public EgitimModulController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var egitim = await _context.EgitimModulleri.ToListAsync();
            return View(egitim);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EgitimModul model)
        {
            _context.EgitimModulleri.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var egitimler = await _context.EgitimModulleri
            .Include(o => o.EgitimKayitlari)
            .ThenInclude( o=> o.Ogrenci)
            .FirstOrDefaultAsync(k =>k.EgitimModulId == id);
            if(egitimler == null)
            {
                return NotFound();
            }
            return View(egitimler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id,EgitimModul model)
        {
            if(id != model.EgitimModulId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(! _context.EgitimModulleri.Any(x =>x.EgitimModulId == model.EgitimModulId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var egitim = await _context.EgitimModulleri.FindAsync(id);
            if(egitim == null)
            {
                return NotFound();
            }
            return View(egitim);
        }

        [HttpPost]
        public async Task<IActionResult>Delete([FromForm]int id)
        {
            var egitim = await _context.EgitimModulleri.FindAsync(id);
            if(egitim == null)
            {
                return NotFound();
            }
            _context.EgitimModulleri.Remove(egitim);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
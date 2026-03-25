using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentEduApp.DataClass;
using StudentEduProject.DataClass;


namespace efcoreApp.Controllers
{
    public class EgitimKayitController:Controller
    {
        private readonly DataContext _context;

        public EgitimKayitController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var EgitimKayitlari = await _context.EgitimKayitlari
            .Include(x =>x.Ogrenci)
            .Include(x =>x.EgitimModul).ToListAsync();
            return View(EgitimKayitlari); 
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(),"Id","AdSoyad"); 

            ViewBag.EgitimModulleri = new SelectList(await _context.EgitimModulleri.ToListAsync(),"EgitimModulId","ModulAdi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EgitimKayit model) 
        {
            model.KayitTarihi = DateTime.Now; 
            _context.EgitimKayitlari.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
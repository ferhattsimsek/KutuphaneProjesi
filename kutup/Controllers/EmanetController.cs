using kutup.Data;
using kutup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutup.Controllers
{
    public class EmanetController : Controller
    {
        private readonly DataContext _context;
        public EmanetController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
           var entity=  await _context.Emanetler.Include(x=>x.kullanıcı).Include(x=>x.kitap).ToListAsync();
            return View(entity);
        }
        public async Task<IActionResult> EmanetVer(int id)
        {
            var entity = _context.Emanetler.Include(x => x.kullanıcı).Include(x => x.kitap).FirstOrDefault(x => x.Id == id);
            entity.GetirdiğiTarih = DateTime.Now;
            entity.getirdimi = true;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Create()
        {
            

            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(Emanet model)
        {
            model.kullanıcı = _context.Kullanıcılar.FirstOrDefault(x=>x.KullanıcıId==model.KullanıcıId);
            model.kitap = _context.Kitaplar.FirstOrDefault(x => x.ISBN == model.KitapId);
            model.AlisTarihi = DateTime.Now;
            model.GetirecegiTarih= DateTime.Now.AddDays(15);
            model.getirdimi = false;
            model.KalanGünSayısı = 15;
            _context.Emanetler.Add(model);
            await _context.SaveChangesAsync();


            return View();
        }
    }
}

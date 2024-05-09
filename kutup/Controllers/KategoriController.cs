using kutup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutup.Controllers
{
    public class KategoriController : Controller
    {
        private readonly DataContext _context;
        public KategoriController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kategori model)
        {
            _context.Kategoriler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> index()
        {
            var kategoriler = await _context.Kategoriler.ToListAsync();
            return View(kategoriler);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var kategori=await _context.Kategoriler.FirstOrDefaultAsync(x=>x.KategoriId==id);
            if (kategori == null) { return NotFound(); }
            return View(kategori);
        }

      

            [HttpPost]
            public async Task<IActionResult> Edit(Kategori model,int id)
            {
            if (id != model.KategoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Kategoriler.Any(o => o.KategoriId == model.KategoriId))
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
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var kategori=await _context.Kategoriler.FirstOrDefaultAsync(x=>x.KategoriId==id);
            if (kategori == null) { return NotFound(); }
            _context.Kategoriler.Remove(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Kategori");
        }


    }
}

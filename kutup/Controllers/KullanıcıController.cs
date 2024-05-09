using kutup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutup.Controllers
{
    public class KullanıcıController : Controller
    {
        private readonly DataContext _context;
        public KullanıcıController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kullanıcı model)
        {
            _context.Kullanıcılar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> index()
        {
            var kullanıcılar = await _context.Kullanıcılar.ToListAsync();
            return View(kullanıcılar);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var kullanıcı = await _context.Kullanıcılar.FirstOrDefaultAsync(x => x.KullanıcıId == id);
            if (kullanıcı == null) { return NotFound(); }
            return View(kullanıcı);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(Kullanıcı model, int id)
        {
            if (id != model.KullanıcıId)
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
                    if (!_context.Kullanıcılar.Any(o => o.KullanıcıId == model.KullanıcıId))
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
            var kullanıcı = await _context.Kullanıcılar.FirstOrDefaultAsync(x => x.KullanıcıId == id);
            if (kullanıcı == null) { return NotFound(); }
            _context.Kullanıcılar.Remove(kullanıcı);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}

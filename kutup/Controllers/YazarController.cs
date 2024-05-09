using kutup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutup.Controllers
{
    public class YazarController : Controller
    {
        private readonly DataContext _context;
        public YazarController(DataContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            var yazarlar = await _context.Yazarlar.ToListAsync();
            return View(yazarlar);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Yazar model)
        {
            _context.Yazarlar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) { return NotFound(); }
            var yazar=_context.Yazarlar.FirstOrDefault(y=>y.YazarId == id);
            if (yazar == null) { return NotFound(); }
            return View(yazar);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Yazar model,int id)
        {
            if (id != model.YazarId)
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
                    if (!_context.Yazarlar.Any(o => o.YazarId == model.YazarId))
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
            var yazar = await _context.Yazarlar.FirstOrDefaultAsync(x => x.YazarId == id);
            if (yazar == null) { return NotFound(); }
            _context.Yazarlar.Remove(yazar);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "yazar");
        }

    }
}

using kutup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutup.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly DataContext _context;
        public AnasayfaController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var kitaplar =await  _context.Kitaplar.ToListAsync();
            return View(kitaplar);

        }
        public async Task<IActionResult> Detay(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kipt = await _context
                                .Kitaplar
                                .Include(o => o.Kategoriler)
                                .Include(o => o.Yazarlar)
                                .Include(o => o.Yorumlar)
                                .ThenInclude(o=>o.Kullanıcı)
                                .FirstOrDefaultAsync(o => o.ISBN == id);

            if (kipt == null)
            {
                return NotFound();
            }

            return View(kipt);

        }
    }
}

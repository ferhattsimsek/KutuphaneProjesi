using kutup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kutup.Controllers
{
    public class KitapController : Controller
    {
        private readonly DataContext _context;
        public KitapController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewBag.Kategoriler =  _context.Kategoriler.ToList();
            ViewBag.Yazarlar = _context.Yazarlar.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kitap model, [FromForm]int[] YazarIds, [FromForm] int[] KategoriIds)
        {
            model.EklenmeTarihi = DateTime.Now;

            model.Yazarlar = _context.Yazarlar.Where(tag => YazarIds.Contains(tag.YazarId)).ToList();
            model.Kategoriler = _context.Kategoriler.Where(tag => KategoriIds.Contains(tag.KategoriId)).ToList();




            _context.Kitaplar.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            var kitaplar = await _context.Kitaplar.Include(z => z.Yazarlar).Include(x => x.Kategoriler).ToListAsync();
            return View(kitaplar);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            ViewBag.Yazarlar = _context.Yazarlar.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var kipt = await _context
                                .Kitaplar
                                .Include(o => o.Kategoriler)
                                .Include(o => o.Yazarlar)
                                .FirstOrDefaultAsync(o => o.ISBN == id);

            if (kipt == null)
            {
                return NotFound();
            }

            return View(kipt);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Kitap model, [FromForm] int[] YazarIds, [FromForm] int[] KategoriIds,int id)
        {
          
            var entity=_context.Kitaplar.FirstOrDefault(i=>i.ISBN==id);
            _context.Kitaplar.Remove(entity);
            await _context.SaveChangesAsync();

            model.Kategoriler = _context.Kategoriler.Where(tag => KategoriIds.Contains(tag.KategoriId)).ToList();
                model.Yazarlar = _context.Yazarlar.Where(tag => YazarIds.Contains(tag.YazarId)).ToList();
                _context.Kitaplar.Add(model);
                await _context.SaveChangesAsync();    

            

            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Delete(int id)
        {
            var entity= _context.Kitaplar.FirstOrDefault(i => i.ISBN == id);
            if(entity == null) { return NotFound(); }
            _context.Kitaplar.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
    }
}

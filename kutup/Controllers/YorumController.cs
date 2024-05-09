using Microsoft.AspNetCore.Mvc;

namespace kutup.Controllers
{
    public class YorumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

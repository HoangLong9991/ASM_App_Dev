using Microsoft.AspNetCore.Mvc;

namespace ASM_App_Dev.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace ASM_App_Dev.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}

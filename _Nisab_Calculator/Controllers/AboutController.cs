using Microsoft.AspNetCore.Mvc;
using _Nisab_Calculator.Models;


namespace _Nisab_Calculator.Controllers
{
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

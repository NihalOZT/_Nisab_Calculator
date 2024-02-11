using _Nisab_Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Eventing.Reader;


namespace _Nisab_Calculator.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}

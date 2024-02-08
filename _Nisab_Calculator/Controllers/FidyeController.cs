using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _Nisab_Calculator.Models;

namespace _Nisab_Calculator.Controllers
{
    [Route("api/[controller]")]
    public class FidyeController : Controller
    {
        [HttpGet]
        [Route("getBakliyatData")]
        public FidyeCalculatorDto getBakliyatFiyatları()
        {
            FidyeCalculatorDto fidyeCalculator = new FidyeCalculatorDto();
            fidyeCalculator.ArpaFiyatı = 60 * 3.500 * 30 * fidyeCalculator.AileÜyesi;
            fidyeCalculator.UnFiyatı = 70 * 1.750 * 30 * fidyeCalculator.AileÜyesi;
            fidyeCalculator.HurmaFiyatı = 300 * 3.500 * 30 * fidyeCalculator.AileÜyesi;
            fidyeCalculator.KuruÜzümFiyatı = 80 * 3.500 * 30 * fidyeCalculator.AileÜyesi;
            fidyeCalculator.BuğdayFiyatı = 40 * 1.750 * 30 * fidyeCalculator.AileÜyesi;

            return fidyeCalculator;
        }
        [HttpPost]
        [Route("calculateFidye")]
        public IActionResult Index([FromForm] FidyeCalculatorDto fidyeCalculator)
        {
            FidyeCalculatorDto calculateFidye = getBakliyatFiyatları();

            return View("Index", calculateFidye);

        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
using _Nisab_Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;


namespace _Nisab_Calculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        [HttpPost]
        [Route("getData")]
        public async Task<Root> getData()
        {
            using var httpClient = new HttpClient();

            var postData = new StringContent("", Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.genelpara.com/embed/doviz.json", postData);


            string content = await response.Content.ReadAsStringAsync();
            Root data = JsonConvert.DeserializeObject<Root>(content);

            return data;
        }

        [HttpGet]
        [Route("getEmtiaData")]
        public Task<Root> getEmtiaData()
        {
            return getData();
        }

        [HttpPost]
        [Route("calculate")]
        public CalculateDto calculatorNisab([FromBody] CalculateDto calculateDto)
        {
            Root root = getData().Result;

            calculateDto.toplam = (Double.Parse(root.USD.Alis) * calculateDto.DolarAdet +
                Double.Parse(root.GBP.Alis) * calculateDto.SterlinAdet +
                Double.Parse(root.EUR.Alis) * calculateDto.EuroAdet +
                Double.Parse(root.GA.Alis) * calculateDto.GramAltınAdet +
                Double.Parse(root.BTC.Alis) * calculateDto.BtcAdet +
                Double.Parse(root.ETH.Alis) * calculateDto.EthAdet +
                Double.Parse(root.XU100.Alis) * calculateDto.XRPAdet -
                calculateDto.borc) / 
                Double.Parse(root.GA.Alis);
            calculateDto.isMalik = false;
            if(calculateDto.toplam > 80.18)
            {
                calculateDto.isMalik = true;
            }
            return calculateDto;
            
        }
        [HttpPost]
        [Route("calculate1")]
        public IActionResult Index([FromBody] CalculateDto calculateDto)
        {
            CalculateDto calculate = calculatorNisab(calculateDto);
            return View("Index");

        }

       
    }
}

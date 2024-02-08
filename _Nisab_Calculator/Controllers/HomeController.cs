﻿using _Nisab_Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;


namespace _Nisab_Calculator.Controllers
{
    public class HomeController : Controller
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

        public CalculateDto calculatorNisab([FromBody] CalculateDto calculateDto)
        {
            Root root = getData().Result;

            calculateDto.toplam = (
                Double.Parse(root.USD.Alis) * calculateDto.DolarAdet +
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
                calculateDto.zekat = calculateDto.toplam / 40;
            }
            return calculateDto;
            
        }


        [HttpPost]
        [Route("calculateNisap")]
        public IActionResult Index([FromForm] CalculateDto calculateDto)
        {
            CalculateDto calculateNisab = calculatorNisab(calculateDto);
            
            return View("Index", calculateNisab);

        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}

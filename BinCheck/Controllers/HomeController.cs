using BinCheck.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BinCheck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreditCardQueryViewModel model)
        {
            var client = new HttpClient();

            var response = await client.GetStringAsync($"https://lookup.binlist.net/{model.CardNumber}");
            var result = JsonConvert.DeserializeObject<ResultViewModel>(response);
            ViewBag.CardInfo = result;
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class CreditCardQueryViewModel
        {
            public object CardNumber { get; internal set; }
        }

        private class ResultViewModel
        {
        }
    }
}
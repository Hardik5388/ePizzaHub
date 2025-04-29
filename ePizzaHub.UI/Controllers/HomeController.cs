using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ePizzaHub.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemServices _itemServices;

        public HomeController(ILogger<HomeController> logger,IItemServices itemServices)
        {
            _logger = logger;
            _itemServices = itemServices;
        }

        public IActionResult Index()
        {
            var item = _itemServices.GetItems();
            return View(item);
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
    }
}

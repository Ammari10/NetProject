using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EStore.Models;
using EStore.Data.Services;

namespace EStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _service;

        public HomeController(ILogger<HomeController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var allProducts = await _service.GetAllAsync(n => n.Company);
            return View(allProducts);
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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Service.Account;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        public HomeController(ILogger<HomeController> logger,ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var response = _productService.GetProductList().Result;
            var loginResponse = JsonConvert.DeserializeObject<List<ProductListDto>>(response.Content.ReadAsStringAsync().Result);

            Response.StatusCode = (int)response.StatusCode;
            if (response.IsSuccessStatusCode)
            {
                return View(loginResponse);
            }
            return View(new List<ProductListDto>());
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

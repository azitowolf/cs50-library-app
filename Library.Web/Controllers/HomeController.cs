using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Library.Utils;
using Library.Services.Interface;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AzureStorageConfig _config;
        private IBookService _bookService { get; }

        public HomeController(ILogger<HomeController> logger, IOptions<AzureStorageConfig> configuration, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
            _config = configuration.Value;
        }

        public async Task<IActionResult> Index()
        {
            //TODO log the framework info 
            var netCoreVer = System.Environment.Version;
            var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; 
            
            _logger.Log(LogLevel.Information, $"Runtime version = {netCoreVer}");
            _logger.Log(LogLevel.Information, $"Framework description = {netCoreVer}");

            var bookList = await _bookService.GetAll(null, null, null, null);
            var homeModel = new HomeViewModel(bookList.ToList());

            return View("Index", homeModel);
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

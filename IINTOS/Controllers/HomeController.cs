using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IINTOS.Models;
using IINTOS.Services;

namespace IINTOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailSender _emailSender;

        public HomeController(EmailSender emailSender, ILogger<HomeController> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await c();
            return View();
        }

        private async Task c()
        {
            await _emailSender.SendEmailAsync("iceptalves@gmail.com",
                                                "IINTOS",
                                                "WAZAAAAAA"
                                                );

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

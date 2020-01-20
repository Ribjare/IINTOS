using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IINTOS.Data;
using IINTOS.Models;
using IINTOS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IINTOS.Controllers
{
    
    public class RegistationController : Controller
    {
        private readonly IINTOSContext _context;
        private readonly EmailSender _emailSender;
        private readonly UserManager<User> _userManager;
        private readonly IServiceProvider _serviceProvider;

        public RegistationController(IINTOSContext context, UserManager<User> userManager, EmailSender emailSender, IServiceProvider serviceProvider)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
            _serviceProvider = serviceProvider;
        }
        // GET: Registation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registation/Create
        public ActionResult Create()
        {
            var nationalityList =  _context.Nationality.ToList();

            ViewBag.Nationality = nationalityList
                    .Select(r => new SelectListItem { Value = r.Id + "", Text = r.Name })
                    .ToList();

            return View();
        }



        // POST: Registation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
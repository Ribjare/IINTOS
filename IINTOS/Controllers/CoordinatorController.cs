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
    public class CoordinatorController : Controller
    {
        private readonly IINTOSContext _context;
        private readonly EmailSender _emailSender;
        private readonly UserManager<User> _userManager;
        private readonly IServiceProvider _serviceProvider;

        public CoordinatorController(IINTOSContext context, EmailSender emailSender, UserManager<User> userManager, IServiceProvider serviceProvider)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }

        // GET: Coordinator
        public async Task<ActionResult> Index()
        {
            var thisUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var aux =  _context.School.Where(p => p.Id == thisUser.SchoolId).FirstOrDefault();

            return View(thisUser);
        }

        public async Task<ActionResult> ProfessorList()
        {
            var thisUser = await _userManager.FindByNameAsync(User.Identity.Name);
            
            return View(_context.User.Where(p => p.SchoolId == thisUser.SchoolId).ToList());
        }

        public async Task<ActionResult> ApproveProfessorList()
        {
            var thisUser = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(_context.User.Where(p => p.SchoolId == thisUser.SchoolId && p.Active == false).ToList());
        }

        public async Task<ActionResult> CreateProfessor()
        {
            var thisUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var aux = _context.School.Where(p => p.Id == thisUser.SchoolId).FirstOrDefault();

            ViewBag.School = thisUser.School;
            ViewBag.Nationality = new SelectList(_context.Country, "Id", "Name");


            return View();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IINTOS.Data;
using IINTOS.Models;
using IINTOS.Services;
using IINTOS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IINTOS.Controllers
{
    /// <summary>
    /// Controller for the registation controler
    /// </summary>
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Index registation, show the diferente types of registation for the public. </summary>
        ///
        /// <remarks>   Daniel Alves, 08/02/2020. </remarks>
        ///
        /// <returns>   A response stream to send to the IndexRegistation View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult IndexRegistation()
        {
            return View();
        }

        // GET: Registation/Create
        public ActionResult Create()
        {

            ViewBag.Nationality = new SelectList(_context.Nationality, "Id", "Name");

            ViewBag.School = new SelectList(_context.School, "Id", "Name");


            return View();
        }

        // GET: Registation/Create
        public ActionResult CreateCoordinator()
        {

            ViewBag.Nationality = new SelectList(_context.Nationality, "Id", "Name");

            return View();
        }

        // POST: Registation/Create
        /// <summary>
        /// Post action for the creation of a coordinator user and it's school, that will be validated by the admin
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns>A action result, view for the index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCoordinator(CoordinatiorSchoolViewModel coordinatiorSchool)
        {
            var user = new User();
            try
            {
                if (ModelState.IsValid)
                {

                    //Create an user object
                    user = new User
                    {
                        Name = coordinatiorSchool.Name,
                        UserName = coordinatiorSchool.Email,
                        Email = coordinatiorSchool.Email,
                        About = coordinatiorSchool.About,
                        PhoneNumber = coordinatiorSchool.PhoneNumber,
                        Active = false,
                        NationalityId = coordinatiorSchool.Nationality,
                    };

                    //Creating the user in the bd
                    var result = await _userManager.CreateAsync(user, coordinatiorSchool.Password);
                    if (result.Succeeded)
                    {
                        //The coordinator has the same privilege of the professor
                        await _userManager.AddToRoleAsync(user, "Coordinator");

                        await _context.SaveChangesAsync();
                        //
                        //TODO: Send email to admin

                        var adminList = await _userManager.GetUsersInRoleAsync("Admin");
/*
                        foreach (var userAux in adminList)
                        {
                           await _emailSender.SendEmailAsync(userAux.Email, "IINTOS - Coordinatior Request", "<p>A new Coordinator have requested to join the platform.</p>" +
                                "<p> Go and check it out!</p>");
                        }
                        */

                        return RedirectToAction("Create", "Schools", new { area = "", coordinator = user.Email});
                    }
                    return View();
                }

                //saida default
                return View();
            }
            catch (Exception e)
            {
                await _userManager.DeleteAsync(user);
                return RedirectToAction(nameof(CreateCoordinator));
            }
        }

        // POST: Registation/Create
        /// <summary>
        ///     Post action for the creation of a professor user
        /// </summary>
        /// <param name="userViewModel">The object that will be a user object</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // 
                    var user = new User
                    {
                        Name = userViewModel.Name,
                        UserName = userViewModel.Email,
                        Email = userViewModel.Email,
                        About = userViewModel.About,
                        PhoneNumber = userViewModel.PhoneNumber,
                        Active = false,
                        NationalityId = userViewModel.Nationality,
                        SchoolId = userViewModel.School
                    };
                    var school = await _context.School
                        .Include(p => p.Professors)
                        .Include(p => p.Coordinator)
                        .FirstOrDefaultAsync(p => p.Id == userViewModel.School);

                    school.Professors.Add(user);

                    //Creating the user in the bd
                    var result = await _userManager.CreateAsync(user, userViewModel.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Professor");
                        // _logger.LogInformation("User created a new account with password.");
                        _context.Update(school);

                        //TODO Send email to coordinator
                        return RedirectToAction(nameof(Index));
                    }
                    return View();
                }
                else
                {
                    ViewData["_alert.type"] = "error";
                    ViewData["_alert.title"] = "Erro";
                    ViewData["_alert.body"] = ". Id:T002";

                }

                //saida default
                return Create();
            }
            catch (Exception e)
            {
                return Create();
            }
        }



    }
}
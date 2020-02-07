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

        // GET: Registation/Create
        public ActionResult Create()
        {
            var nationalityList = _context.Nationality.ToList();
            var roleList = _context.Roles.ToList();
            var schoolList = _context.School.ToList();

            ViewBag.Nationality = nationalityList
                    .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                    .ToList();

            ViewBag.Roles = roleList
                   .Select(r => new SelectListItem { Value = r.Id, Text = r.Name })
                   .ToList();

            ViewBag.School = schoolList
                  .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                  .ToList();


            return View();
        }

        // GET: Registation/Create
        public ActionResult CreateCoordinator()
        {
            var nationalityList = _context.Nationality.ToList();
            var roleList = _context.Roles.ToList();
            var schoolList = _context.School.ToList();
            var cityList = _context.City.ToList();

            ViewBag.Nationality = nationalityList
                    .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                    .ToList();

            ViewBag.Roles = roleList
                   .Select(r => new SelectListItem { Value = r.Id, Text = r.Name })
                   .ToList();

            ViewBag.School = schoolList
                  .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                  .ToList();

            ViewBag.City = cityList.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();


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

                    var nationality = await _context.Nationality.FirstOrDefaultAsync(p => p.Id.ToString().Equals(coordinatiorSchool.Nationality));

                    // Checks if the school already exits
                    var x = _context.School.Where(p => p.Name.Equals(coordinatiorSchool.SchoolName));
                    if (x == null)
                    {
                        // TODO return the error message
                        return View();
                    }

                    //Create a school to associate the user with
                    var school = new School
                    {
                        Name = coordinatiorSchool.SchoolName,
                        Address = coordinatiorSchool.SchoolAddress,
                        Website = coordinatiorSchool.SchoolWebsite
                    };

                    //Create an user object
                    user = new User
                    {
                        Name = coordinatiorSchool.Name,
                        UserName = coordinatiorSchool.Email,
                        Email = coordinatiorSchool.Email,
                        About = coordinatiorSchool.About,
                        PhoneNumber = coordinatiorSchool.PhoneNumber,
                        Active = false,
                        Nationality = nationality,
                        School = school
                    };


                    //Creating the user in the bd
                    var result = await _userManager.CreateAsync(user, coordinatiorSchool.Password);
                    if (result.Succeeded)
                    {
                        //The coordinator has the same privilege of the professor
                        await _userManager.AddToRoleAsync(user, "Coordinator");
                        await _userManager.AddToRoleAsync(user, "Professor");


                        school.Coordinator = user;
                        _context.School.Add(school);

                        await _context.SaveChangesAsync();


                        return RedirectToAction(nameof(Index));
                    }
                    return View();
                }

                //saida default
                return View();
            }
            catch (Exception e)
            {
                await _userManager.DeleteAsync(user);
                return CreateCoordinator();
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
                    var nationality = await _context.Nationality.FirstOrDefaultAsync(p => p.Id.ToString().Equals(userViewModel.Nationality));
                    var school = await _context.School.FirstOrDefaultAsync(p => p.Name.Equals(userViewModel.School));
                    var user = new User
                    {
                        Name = userViewModel.Name,
                        UserName = userViewModel.Email,
                        Email = userViewModel.Email,
                        About = userViewModel.About,
                        PhoneNumber = userViewModel.PhoneNumber,///ver do parse de string para int
                        Active = false,
                        Nationality = nationality,
                        School = school
                    };

                    //Creating the user in the bd
                    var result = await _userManager.CreateAsync(user, userViewModel.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Professor");
                        // _logger.LogInformation("User created a new account with password.");


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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return Create();
            }
        }



    }
}
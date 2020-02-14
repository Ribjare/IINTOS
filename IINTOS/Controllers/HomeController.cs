using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IINTOS.Models;
using IINTOS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IINTOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailSender _emailSender;
        private readonly UserManager<User> _userManager;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(EmailSender emailSender, UserManager<User> userManager, IServiceProvider serviceProvider, ILogger<HomeController> logger)
        {
            _emailSender = emailSender;
            _serviceProvider = serviceProvider;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //await c();
            //await createRolesandUsers();
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the about page. </summary>
        ///
        /// <remarks>   Daniel Alves, 09/02/2020. </remarks>
        ///
        /// <returns>   An IActionResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult About()
        {
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the partner page. </summary>
        ///
        /// <remarks>   Daniel Alves, 09/02/2020. </remarks>
        ///
        /// <returns>   An IActionResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult Partner()
        {
            return View();
        }
        //Partners pages -----------------

        public IActionResult IpsPage()
        {
            return View();
        }
        public IActionResult OlomucPage()
        {
            return View();
        }

        public IActionResult SaramagoPage()
        {
            return View();
        }

        public IActionResult VallauriPage()
        {
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

        /// <summary>
        /// Creates the roles, this method needs to moved to another place
        /// </summary>
        /// <returns></returns>
        private async Task createRolesandUsers()
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            bool x = await roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new User();
                user.UserName = "IINTOS_DEV";
                user.Email = "iintosdev@hotmail.com";

                string userPWD = "mobilidade";

                IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = await _userManager.AddToRoleAsync(user, "Admin");
                }
            }

            // creating Creating Manager role     
            x = await roleManager.RoleExistsAsync("Coordinatior");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Coordinatior";
                await roleManager.CreateAsync(role);
            }

            // creating Creating Employee role     
            x = await roleManager.RoleExistsAsync("Professor");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Professor";
                await roleManager.CreateAsync(role);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IINTOS.Data;
using IINTOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IINTOS.Controllers
{
    /// <summary>
    /// Controler for the admins
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IINTOSContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(IINTOSContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListUsers()
        {

            Dictionary<User, string> list = new Dictionary<User, string>();

            foreach (User user in _userManager.Users.ToList())
            {
                List<string> roles = new List<string>(await _userManager.GetRolesAsync(user));
                if (roles.Count <= 0)
                {
                    list.Add(user, "Sem permissões");
                }
                else if (roles.Count == 1)
                {
                    list.Add(user, roles[0]);
                }
                else
                {
                    string roleList = "";
                    foreach (string role in roles)
                    {
                        roleList += role + ", ";
                    }
                    list.Add(user, roleList.Substring(roleList.Length - 2));
                }


            }

            return View(list);
        }


    }
}
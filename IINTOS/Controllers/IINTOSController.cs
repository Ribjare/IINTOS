using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IINTOS.Data;
using IINTOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IINTOS.Controllers
{
    [Authorize(Roles = "Admin,IINTOS-Coordinator")]
    public class IINTOSController : Controller
    {
        private readonly IINTOSContext _context;
        private readonly UserManager<User> _userManager;

        public IINTOSController(IINTOSContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: IINTOS
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ListUsers()
        {

            Dictionary<User, string> list = new Dictionary<User, string>();

            foreach (User user in _userManager.Users.ToList())
            {
                List<string> roles = new List<string>(await _userManager.GetRolesAsync(user));

                if (roles.Contains("IINTOS-Professor") || roles.Contains("IINTOS-Coordinator"))
                {
                    list.Add(user, roles[0]);
                }
            }

            return View(list);
        }


    }
}
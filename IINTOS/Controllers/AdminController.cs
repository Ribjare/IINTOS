using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using IINTOS.Data;
using IINTOS.Models;
using IINTOS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IINTOS.Controllers
{
    /// <summary>
    /// Controler for the admins
    /// </summary>
    [Authorize(Roles = "Admin,Coordinator")]
    public class AdminController : Controller
    {
        private readonly IINTOSContext _context;
        private readonly UserManager<User> _userManager;
        private readonly EmailSender _emailSender;


        public AdminController(IINTOSContext context, UserManager<User> userManager, EmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;

        }

        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveUser()
        {
            Dictionary<User, string> list = new Dictionary<User, string>();

            foreach (User user in _userManager.Users.Where(p => p.Active == false).ToList())
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


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Action to approve a user. </summary>
        ///
        /// <remarks>   Daniel Alves, 08/02/2020. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   An asynchronous result that yields an IActionResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> ApproveAction(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Active = true;
            if(await _userManager.IsInRoleAsync(user, "Coordinator"))
            {
                 _context.School.Where(p => p.Coordinator == user).FirstOrDefault();
                user.SchoolCoordination.Active = true;
            }

            await _userManager.UpdateAsync(user);

            // Send the email with the link
            var callbackUrl = Url.Page(
                        "/");

            var subject = $"You've been approved into IINTOS platform! <p>Get in to start explore this platform" +
                $"<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.</p>";

            //TODO Send some email
            await _emailSender.SendEmailAsync(user.Email, "IINTOS - Approved", subject);

            if (User.IsInRole("Admin")){ 
                return RedirectToAction(nameof(ListUsers));
            }
            //if (User.IsInRole("Coordinator")){
                return RedirectToAction("ProfessorList", "Coordinator");
            //}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the action described by ID. </summary>
        ///
        /// <remarks>   Daniel Alves, 08/02/2020. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   An asynchronous result that yields an IActionResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<IActionResult> DeleteAction(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);

            //TODO Send some email

            return RedirectToAction(nameof(ListUsers));
        }
    }
}
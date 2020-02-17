using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IINTOS.Data;
using IINTOS.Models;
using Microsoft.AspNetCore.Identity;

namespace IINTOS.Controllers
{
	public class CalendarController : Controller
	{
		private readonly IINTOSContext _context;
		private readonly UserManager<User> _userManager;

		public CalendarController(IINTOSContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: Calendar
		public ActionResult Index()
		{
			return View();
		}
	}
}

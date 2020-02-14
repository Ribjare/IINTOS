using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IINTOS.Data;
using IINTOS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using IINTOS.Services;
using Microsoft.AspNetCore.Identity;

namespace IINTOS
{
	public class ProjectController : Controller
	{
		private readonly IINTOSContext _context;
		private UserManager<User> _userManager;

		public ProjectController(IINTOSContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: Project
		public async Task<IActionResult> Index()
		{
			return View(await _context.Project.ToListAsync());
		}

		// GET: Project/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var project = await _context.Project
					.FirstOrDefaultAsync(m => m.Id == id);
			if (project == null)
			{
				return NotFound();
			}

			return View(project);
		}

		// GET: Project/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Project/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Goal,Description,Links,TargetAudience,Type")] Project project)
		{

			if (ModelState.IsValid)
			{
				using (var dbContextTransaction = _context.Database.BeginTransaction())
				{
					_context.Add(project);
					await _context.SaveChangesAsync();
					int projectId = project.Id;

					User user = await _userManager.GetUserAsync(User);
					int schoolId = user.SchoolId;

					if (!(schoolId >= 1))
					{
						dbContextTransaction.Rollback();
						Console.WriteLine("SchoolId is NULL");
					}

					SchoolProject schoolProject = new SchoolProject(projectId, schoolId);
					_context.Add(schoolProject);
					await _context.SaveChangesAsync();

					dbContextTransaction.Commit();
				}


				return RedirectToAction(nameof(Index));
			}

			return View(project);
		}

		// GET: Project/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var project = await _context.Project.FindAsync(id);
			if (project == null)
			{
				return NotFound();
			}
			return View(project);
		}

		// POST: Project/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Goal,Description,Links,TargetAudience,Type")] Project project)
		{
			if (id != project.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(project);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProjectExists(project.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(project);
		}

		// GET: Project/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var project = await _context.Project
					.FirstOrDefaultAsync(m => m.Id == id);
			if (project == null)
			{
				return NotFound();
			}

			return View(project);
		}

		// POST: Project/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var project = await _context.Project.FindAsync(id);
			_context.Project.Remove(project);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Project/SchoolProject/5
		public async Task<IActionResult> SchoolProject(int? id)
		{

			Console.WriteLine(id);
			List<School> allSchools = await _context.School.ToListAsync();

			List<SchoolProject> schoolProject = await _context.SchoolProject
					.Where(m => m.ProjectId == id)
					.ToListAsync();


			IEnumerable<School> schools = schoolProject.Join(
			allSchools,
			schoolProject => schoolProject.SchoolId,
			school => school.Id,
			(schoolProject, school) => new School
			{
				Name = school.Name,
				Address = school.Address,
				Website = school.Website
			}
			);

			return View(schools);
		}

		private bool ProjectExists(int id)
		{
			return _context.Project.Any(e => e.Id == id);
		}
	}
}

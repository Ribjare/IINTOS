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
    public class SchoolsController : Controller
    {
        private readonly IINTOSContext _context;
        private readonly UserManager<User> _userManager;

        public SchoolsController(IINTOSContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Schools
        public async Task<IActionResult> Index()
        {
            return View(await _context.School.ToListAsync());
        }

        // GET: Schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School
                .Include(p => p.Coordinator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }


        public IActionResult Create(String? coordinator)
        {
            ViewBag.Coordinator = coordinator;

            ViewBag.Cities = new SelectList(_context.City.Include(p => p.State).ThenInclude(p => p.Country).Where(p => p.State.Country.Name.Equals("Portugal")), "Id", "Name");

            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Website,CityId")] School school, string? coordinatorId)
        {
            if (ModelState.IsValid)
            {
                if (coordinatorId != null)
                {
                    var user = await _userManager.FindByEmailAsync(coordinatorId);
                    user.School = school;
                    school.Coordinator = user;

                    _context.Add(school);
                    _context.Update(user);
                }
                else
                {
                    _context.Add(school);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Website")] School school)
        {
            if (id != school.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.Id))
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
            return View(school);
        }

        // GET: Schools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School
                .FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var school = await _context.School.FindAsync(id);
            _context.School.Remove(school);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }
    }
}

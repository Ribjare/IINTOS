using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IINTOS.Data;
using IINTOS.Models;

namespace IINTOS
{
    public class SchoolProjectController : Controller
    {
        private readonly IINTOSContext _context;

        public SchoolProjectController(IINTOSContext context)
        {
            _context = context;
        }

        // GET: SchoolProject
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchoolProject.ToListAsync());
        }

        // GET: SchoolProject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolProject = await _context.SchoolProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolProject == null)
            {
                return NotFound();
            }

            return View(schoolProject);
        }

        // GET: SchoolProject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolProject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,SchoolId")] SchoolProject schoolProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolProject);
        }

        // GET: SchoolProject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolProject = await _context.SchoolProject.FindAsync(id);
            if (schoolProject == null)
            {
                return NotFound();
            }
            return View(schoolProject);
        }

        // POST: SchoolProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,SchoolId")] SchoolProject schoolProject)
        {
            if (id != schoolProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolProjectExists(schoolProject.Id))
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
            return View(schoolProject);
        }

        // GET: SchoolProject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolProject = await _context.SchoolProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolProject == null)
            {
                return NotFound();
            }

            return View(schoolProject);
        }

        // POST: SchoolProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolProject = await _context.SchoolProject.FindAsync(id);
            _context.SchoolProject.Remove(schoolProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolProjectExists(int id)
        {
            return _context.SchoolProject.Any(e => e.Id == id);
        }
    }
}

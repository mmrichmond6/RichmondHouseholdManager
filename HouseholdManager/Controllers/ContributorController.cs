using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using HouseholdManager.Data;

namespace HouseholdManager.Controllers
{
    public class ContributorController : Controller
    {
        private readonly HouseholdManagerDbContext _context;

        public ContributorController(HouseholdManagerDbContext context)
        {
            _context = context;
        }

        // GET: Contributor
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contributors.ToListAsync());
        }


        // GET: Contributor/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Contributor());
            else
                return View(_context.Contributors.Find(id));
        }

        // POST: Contributor/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ContributorId,ContributorName,ContributorType,ContributorEmail,ContributorIcon")] Contributor contributor)
        {
            if (ModelState.IsValid)
            {
                if (contributor.ContributorId == 0)
                    _context.Add(contributor);
                else
                    _context.Update(contributor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(contributor);
        }


        // POST: Contributor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contributors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contributor'  is null.");
            }
            var contributor = await _context.Contributors.FindAsync(id);
            if (contributor != null)
            {
                _context.Contributors.Remove(contributor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }

    }
}

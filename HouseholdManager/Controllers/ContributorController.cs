using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Data.API;

namespace HouseholdManager.Controllers
{
    [Authorize(Roles = "Administrator, User")]
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
            var applicationDbContext = _context.Contributors.Include(t => t.Household).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Contributor/AddOrEdit
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            IconRequestor req = new IconRequestor();
            List<Icon> icons = await req.GetIconsFromApi();
            ViewBag.Icons = icons;
            PopulateHouseholds();
            PopulateIdentityUsers();
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
        public async Task<IActionResult> AddOrEdit([Bind("ContributorId,ContributorType,ContributorIcon,HouseholdId,UserName")] Contributor contributor)
        {
            if (ModelState.IsValid)
            {
                if (contributor.ContributorId == 0)
                    _context.Add(contributor);
                else
                    _context.Update(contributor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Contributor");
            }
            PopulateHouseholds();
            PopulateIdentityUsers();
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
            return RedirectToAction("Index", "Contributor");
        }

        [NonAction]
        public void PopulateHouseholds()
        {
            var HouseholdCollection = _context.Households.ToList();
            Household DefaultHousehold = new Household() { HouseholdId = 0, HouseholdName = "Choose a Household" };
            HouseholdCollection.Insert(0, DefaultHousehold);
            ViewBag.Households = HouseholdCollection;
        }

        [NonAction]
        public void PopulateIdentityUsers()
        {
            var UserCollection = _context.AppUsers.ToList();
            AppUser DefaultUser = new AppUser() { Id = "", UserName = "Choose an Identity User"};
            UserCollection.Insert(0, DefaultUser);
            ViewBag.IdentityUsers = UserCollection;
        }

    }
}

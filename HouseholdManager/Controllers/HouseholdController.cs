﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Data;
using HouseholdManager.Models;

namespace HouseholdManager.Controllers
{
    public class HouseholdController : Controller
    {
        private readonly HouseholdManagerDbContext _context;

        public HouseholdController(HouseholdManagerDbContext context)
        {
            _context = context;
        }

        // GET: Household/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new Models.Household());
            else
                return View(_context.Rooms.Find(id));
        }

        // POST: Household/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("HouseholdId,HouseholdName,HouseholdIcon")] Household household)
        {
            if (ModelState.IsValid)
            {
                if (household.HouseholdId == 0)
                    _context.Add(household);
                else
                    _context.Update(household);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(household);
        }


        // POST: Household/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Households == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Households'  is null.");
            }
            var household = await _context.Households.FindAsync(id);
            if (household != null)
            {
                _context.Households.Remove(household);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }

    }
}

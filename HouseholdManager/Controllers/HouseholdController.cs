using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Data.API;

namespace HouseholdManager.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HouseholdController : Controller
    {
        private readonly HouseholdManagerDbContext _context;

        public HouseholdController(HouseholdManagerDbContext context)
        {
            _context = context;
        }

        // GET: Household
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Households;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Household/AddOrEdit
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            IconRequestor req = new IconRequestor();
            List<Icon> icons = await req.GetIconsFromApi();
            ViewBag.Icons = icons;
            if (id == 0)
                return View(new Household());
            else
                return View(_context.Households.Find(id));
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
                return RedirectToAction("Index", "Household");
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
            return RedirectToAction("Index", "Household");
        }
    }    
}

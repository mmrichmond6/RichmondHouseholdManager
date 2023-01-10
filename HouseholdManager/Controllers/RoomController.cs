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
    public class RoomController : Controller
    {
        private readonly HouseholdManagerDbContext _context;

        public RoomController(HouseholdManagerDbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rooms.ToListAsync());
        }

        // GET: Room/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
           
            if (id == 0)
                return View(new Models.Room());
            else
                return View(_context.Rooms.Find(id));
        }

        // POST: Room/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("RoomId,RoomName,RoomIcon")] Room room)
        {
            if (ModelState.IsValid)
            {
                if (room.RoomId == 0)
                    _context.Add(room);
                else
                    _context.Update(room);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(room);
        }


        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rooms'  is null.");
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }

    }
}

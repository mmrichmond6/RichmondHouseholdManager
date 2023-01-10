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
    public class MissionController : Controller
    {
        private readonly HouseholdManagerDbContext _context;

        public MissionController(HouseholdManagerDbContext context)
        {
            _context = context;
        }

        // GET: Mission
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Missions.Include(t => t.Room).Include(u => u.Contributor);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Mission/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateRooms();
            PopulateContributors();
            if (id == 0)
                return View(new Models.Mission());
            else
                return View(_context.Missions.Find(id));
        }

        // POST: Mission/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("MissionId,MissionName,MissionIcon,MissionInstructions,MissionDate,RoomId,MissionPoints,ContributorId,MissionStatus")] Models.Mission mission)
        {
            if (ModelState.IsValid)
            {
                if (mission.MissionId == 0)
                    _context.Add(mission);
                else
                    _context.Update(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            PopulateRooms();
            PopulateContributors();
            return View(mission);
        }



        // POST: Mission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Missions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Missions'  is null.");
            }
            var mission = await _context.Missions.FindAsync(id);
            if (mission != null)
            {
                _context.Missions.Remove(mission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }

        [NonAction]
        public void PopulateRooms()
        {
            var RoomCollection = _context.Rooms.ToList();
            Room DefaultRoom = new Room() { RoomId = 0, RoomName = "Choose a room"};
            RoomCollection.Insert(0,DefaultRoom);
            ViewBag.Rooms = RoomCollection;
        }

        [NonAction]
        public void PopulateContributors()
        {
            var ContributorCollection = _context.Contributors.ToList();
            Contributor DefaultContributor = new Contributor() { ContributorId = 0, ContributorName = "Choose a contributor" };
            ContributorCollection.Insert(0, DefaultContributor);
            ViewBag.Contributors = ContributorCollection;
        }
    }
}

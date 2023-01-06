using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;

namespace HouseholdManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tasks.Include(t => t.Room);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Task/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateRooms();
            PopulateUsers();
            if (id == 0)
                return View(new Models.Task());
            else
                return View(_context.Tasks.Find(id));
        }

        // POST: Task/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TaskId,TaskName,TaskIcon,Instructions, Date, RoomId,Points,UserId")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                    _context.Add(task);
                else
                    _context.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", task.RoomId);
            ViewData["RoomId"] = new SelectList(_context.Users, "UserId", "UserName", task.UserId);
            return View(task);
        }



        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tasks'  is null.");
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void PopulateRooms()
        {
            var RoomCollection = _context.Rooms.ToList();
            Room DefaultRoom = new Room() { RoomId = 0, Name = "Choose a room"};
            RoomCollection.Insert(0,DefaultRoom);
            ViewBag.Rooms = RoomCollection;
        }

        [NonAction]
        public void PopulateUsers()
        {
            var UserCollection = _context.Users.ToList();
            User DefaultUser = new User() { UserId = 0, UserName = "Choose a user" };
            UserCollection.Insert(0, DefaultUser);
            ViewBag.Users = UserCollection;
        }
    }
}

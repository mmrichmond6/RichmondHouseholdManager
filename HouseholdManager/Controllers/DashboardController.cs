using HouseholdManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult> Index()
        {
            //Last 7 Days
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Models.Task> SelectedTasks = await _context.Tasks
                .Include(t => t.Room).Include(u => u.User)
                .Where(y => y.Date>= StartDate && y.Date<= EndDate)
                .ToListAsync();


            return View();
        }
    }
}

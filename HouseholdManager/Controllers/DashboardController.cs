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

            List<Models.Task> allTasks = await _context.Tasks
                .Where(y => y.Date >= StartDate && y.Date <= EndDate)
                .ToListAsync();
            int CountAll = allTasks.Count();

            List<Models.Task> SelectedTasksToDo = await _context.Tasks
                .Include(t => t.Room).Include(u => u.User)
                .Where(y => y.Date>= StartDate && y.Date<= EndDate && y.Type == "ToDo")
                .ToListAsync();
            ViewBag.SelectedTasksToDo = SelectedTasksToDo;
            int CountToDo = SelectedTasksToDo.Count();

            List<Models.Task> SelectedTasksDone = await _context.Tasks
                .Include(t => t.Room).Include(u => u.User)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate && y.Type == "Done")
                .ToListAsync();
            ViewBag.SelectedTasksDone = SelectedTasksDone;
            int CountDone = SelectedTasksDone.Count();

            //Doughnut Chart-Tasks done by User
            ViewBag.DoughnutChartData = SelectedTasksDone
                .GroupBy(j => j.User.UserId)
                .Select(k => new
                {
                    userNameWithIcon = k.First().User.UserNameWithIcon + " " + k.First().User.UserName,
                    amount = k.Sum(j => j.Points),
                    formattedAmount = k.Sum(j => j.Points).ToString("0"),
                })
                .ToList();

            //Recent tasks
            ViewBag.RecentTasks = await _context.Tasks
                .Include(t => t.Room).Include(u => u.User)
                .OrderByDescending(j => j.Date)
                .Take(8)
                .ToListAsync();

            return View();
        }
    }
}

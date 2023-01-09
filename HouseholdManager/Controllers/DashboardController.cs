using HouseholdManager.Data;
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

            List<Models.Mission> allMissions = await _context.Missions
                .Where(y => y.MissionDate >= StartDate && y.MissionDate <= EndDate)
                .ToListAsync();
            int CountAll = allMissions.Count();

            List<Models.Mission> SelectedMissionsToDo = await _context.Missions
                .Include(t => t.Room).Include(u => u.User)
                .Where(y => y.MissionDate>= StartDate && y.MissionDate<= EndDate && y.MissionStatus == "ToDo")
                .ToListAsync();
            ViewBag.SelectedMissionsToDo = SelectedMissionsToDo;
            int CountToDo = SelectedMissionsToDo.Count();

            List<Models.Mission> SelectedMissionsDone = await _context.Missions
                .Include(t => t.Room).Include(u => u.User)
                .Where(y => y.MissionDate >= StartDate && y.MissionDate <= EndDate && y.MissionStatus == "Done")
                .ToListAsync();
            ViewBag.SelectedMissionsDone = SelectedMissionsDone;
            int CountDone = SelectedMissionsDone.Count();

            //Doughnut Chart-Missions done by User
            ViewBag.DoughnutChartData = SelectedMissionsDone
                .GroupBy(j => j.User.UserId)
                .Select(k => new
                {
                    userNameWithIcon = k.First().User.UserNameWithIcon + " " + k.First().User.UserName,
                    amount = k.Sum(j => j.MissionPoints),
                    formattedAmount = k.Sum(j => j.MissionPoints).ToString("0"),
                })
                .ToList();

            //Recent missions
            ViewBag.RecentMissions = await _context.Missions
                .Include(t => t.Room).Include(u => u.User)
                .OrderByDescending(j => j.MissionDate)
                .Take(8)
                .ToListAsync();

            return View();
        }
    }
}

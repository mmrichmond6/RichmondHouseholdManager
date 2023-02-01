using HouseholdManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Controllers
{

    [Authorize(Roles = "Administrator, User")]
    public class DashboardController : Controller
    {
        private readonly HouseholdManagerDbContext _context;

        public DashboardController(HouseholdManagerDbContext context)
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
                .Include(t => t.Room).Include(u => u.Contributor)
                .Where(y => y.MissionDate>= StartDate && y.MissionDate<= EndDate && y.MissionStatus == "ToDo")
                .ToListAsync();
            ViewBag.SelectedMissionsToDo = SelectedMissionsToDo;
            int CountToDo = SelectedMissionsToDo.Count();

            List<Models.Mission> SelectedMissionsDone = await _context.Missions
                .Include(t => t.Room).Include(u => u.Contributor)
                .Where(y => y.MissionDate >= StartDate && y.MissionDate <= EndDate && y.MissionStatus == "Done")
                .ToListAsync();
            ViewBag.SelectedMissionsDone = SelectedMissionsDone;
            int CountDone = SelectedMissionsDone.Count();

            //Doughnut Chart-Missions done by Contributor
            ViewBag.DoughnutChartData = SelectedMissionsDone
                .GroupBy(j => j.Contributor.ContributorId)
                .Select(k => new
                {
                    contributorNameWithIcon = k.First().Contributor.ContributorIcon + " " + k.First().Contributor.UserName,
                    amount = k.Sum(j => j.MissionPoints),
                    formattedAmount = k.Sum(j => j.MissionPoints).ToString("0"),
                })
                .ToList();

            //Recent missions
            ViewBag.RecentMissions = await _context.Missions
                .Include(t => t.Room).Include(u => u.Contributor)
                .OrderByDescending(j => j.MissionDate)
                .Take(8)
                .ToListAsync();

            return View();
        }
    }
}

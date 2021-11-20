using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using System.Diagnostics;
using AutoMapper;
using DatabaseAccessLayer.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Services.Interfaces;

namespace SportsCompetition.Controllers
{    
    public class HomeController : SportsCompetitionController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompetitionService _competitionService;

        public HomeController(ILogger<HomeController> logger, ICompetitionService competitionService)
        {
            _logger = logger;
            _competitionService = competitionService;
        }

        public IActionResult Index()
        {
            var competitionsViewModel = _competitionService.GetCompetitionsViewModel();
            return (GetIndexPage(competitionsViewModel));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(Services.Models.Competition inputModel)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

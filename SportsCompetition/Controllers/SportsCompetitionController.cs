using AutoMapper;
using DatabaseAccessLayer;
using DatabaseAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.Linq;

namespace SportsCompetition.Controllers
{
    public class SportsCompetitionController : Controller
    {
        public SportsCompetitionController()
        { }

        internal string GetCurrentUserID()
        {
            if (!User.Claims.Any())
                return null;

            var currentUserID = User.Claims.Where(u => u.Type.Contains("nameidentifier")).FirstOrDefault()?.Value;
            return (!string.IsNullOrEmpty(currentUserID)) ? currentUserID : null;                
        }

        internal ViewResult GetIndexPage(CompetitionsViewModel competitionsViewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("LoggedUserIndex", competitionsViewModel);
            }
            else
            {
                return View("Index", competitionsViewModel);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services;

namespace SportsCompetition.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompetitionController : SportsCompetitionController
    {
        private readonly ILogger<CompetitionController> _logger;
        private readonly ICompetitionTypeService _competitionTypeService;

        public CompetitionController(ILogger<CompetitionController> logger, ICompetitionTypeService competitionTypeService)
        {
            _logger = logger;
            _competitionTypeService = competitionTypeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCompetitionTypes()
        {
            var allCompetitionTypes = JsonConvert.SerializeObject(_competitionTypeService.GetAllCompetitionTypes());
            return Ok(allCompetitionTypes);
        }
    }
}

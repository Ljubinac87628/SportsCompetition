using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Interfaces;

namespace SportsCompetition.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserGroupController : SportsCompetitionController
    {
        private ILogger<UserGroupController> _logger;
        private readonly IUserGroupService _userGroupService;

        public UserGroupController(ILogger<UserGroupController> logger, IUserGroupService userGroupService)
        {
            _logger = logger;
            _userGroupService = userGroupService;
        }

        [HttpGet]
        public IActionResult GetUserGroupRoles()
        {
            var userGroupRoles = JsonConvert.SerializeObject(_userGroupService.GetUserGroupRoles(GetCurrentUserID()));
            return Ok(userGroupRoles);
        }
    }
}

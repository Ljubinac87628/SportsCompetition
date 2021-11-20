using Services.Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserGroupService
    {
        List<string> GetUserGroupRoles(string userID);
    }
}

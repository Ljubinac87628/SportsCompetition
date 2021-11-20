using DatabaseAccessLayer.Repositories;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserGroupService : IUserGroupService
    {
        public UserGroupService()
        {
        }

        public List<string> GetUserGroupRoles(string userID)
        {
            using (var uow = new UnitOfWork())
            {
                if (!string.IsNullOrEmpty(userID) && uow.UserRepository.Any(c => c.Id == userID))
                {
                    var userGroupID = uow.UserRepository.First(c => c.Id == userID).UserGroupID;
                    var roleNames = uow.UserGroupRolesRepository.Find(c => c.UserGroupId == userGroupID, "Role").Select(c => c.Role.Name).ToList();
                    return roleNames;
                }
                return new List<string>();
            }
        }
    }
}

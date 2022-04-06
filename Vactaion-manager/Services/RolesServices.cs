using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly VacationManagerContext managerContext;

        public RolesServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public IDictionary<string, int> GetAllRolesAndCount()
        {
            IEnumerable<User> users = this.managerContext.Users;
            IEnumerable<Role> roles = this.managerContext.Roles;

            var dictionary = new Dictionary<string, int>();

            foreach (var item in roles)
            {
                if (!dictionary.ContainsKey(item.Type))
                {
                    dictionary.Add(item.Type, 0);
                }
            }

            foreach (var item in users)
            {
                if (dictionary.ContainsKey(item.Role.Type))
                {
                    dictionary[item.Role.Type]++;
                }
            }

            return dictionary;
        }

        public IEnumerable<User> GetAllUsersByRole(string role)
        {
            var list = this.managerContext
                .Users
                .OrderBy(u => u.Id)
                .Where(u => u.Role.Type == role)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                })
                .ToList();

            return list;
        }
    }
}

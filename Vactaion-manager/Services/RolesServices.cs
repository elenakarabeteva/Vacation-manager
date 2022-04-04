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

        //public IDictionary<string, int> GetAllRolesAndCount()
        //{
        //    var dictionary = this.managerContext
        //        .
        //}

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

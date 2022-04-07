using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public interface IRolesServices
    {
        IEnumerable<User> GetAllUsersByRole(string role);

        //roles and their users count
        IDictionary<string, int> GetAllRolesAndCount();

        Task<int> Create(string type);

        Task Delete(int roleId);

        Task Update(string type);
    }
}

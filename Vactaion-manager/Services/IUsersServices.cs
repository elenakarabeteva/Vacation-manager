using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public interface IUsersServices
    {
        User GetByUsername(string username);

        IEnumerable<User> GetAllByFirstName(string firstName);

        IEnumerable<User> GetAllByLastName(string lastName);

        IEnumerable<User> GetAllByRole(string role);

        IEnumerable<User> AddTeamToUser(int id, Team team);

        //IEnumerable<Vacation> GetAllVacationsByUser(int id);
    }
}

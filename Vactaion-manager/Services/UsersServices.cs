using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly VacationManagerContext managerContext;

        public UsersServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        //all users / pages
        //queries for vacations

        public IEnumerable<User> GetAllByFirstName(string firstName)
        {
            var list = this.managerContext
                .Users
                .OrderBy(u => u.Id)
                .Where(u => u.FirstName == firstName)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                    Role = u.Role,
                    Team = u.Team
                })
                .ToList();

            return list;
        }

        public IEnumerable<User> GetAllByLastName(string lastName)
        {
            var list = this.managerContext
                .Users 
                .OrderBy(u => u.Id)
                .Where(u => u.Surname == lastName)
                .Select(u => new User 
                { 
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                    Role = u.Role,
                    Team = u.Team
                })
                .ToList();

            return list;
        }

        public IEnumerable<User> GetAllByRole(string role)
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
                    Team = u.Team
                })
                .ToList();

            return list;
        }

        //public IEnumerable<Vacation> GetAllVacationsByUser(int id)
        //{
            
        //}

        public User GetByUsername(string username)
        {
            User user = this.managerContext
                .Users
                .FirstOrDefault(u => u.UserName.Any(un => u.UserName == username));
            return user;
        }
    }
}

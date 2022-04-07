using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;
using Vactaion_manager.Models.Users;

namespace Vactaion_manager.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly VacationManagerContext managerContext;

        public UsersServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public IEnumerable<User> AddTeamToUser(int id, Team team)
        {
            var temp = this.managerContext
                .Users.Where(u => u.Id == id)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                    Role = u.Role,
                    Team = team
                });

            return temp;
        }

        public async Task<int> Create(int userId, int teamId, CreateUserInputModel inputModel)
        {
            Role role = this.managerContext.Roles.FirstOrDefault(r => r.Id == userId);
            Team team = this.managerContext.Teams.FirstOrDefault(t => t.Id == teamId);

            if (role == null || team == null)
            {
                throw new ArgumentNullException("Could not find anything!");
            }

            User user = new User()
            {
                UserName = inputModel.UserName,
                Password = inputModel.Password,
                FirstName = inputModel.FirstName,
                Surname = inputModel.Surname,
                Role = role,
                Team = team,
            };

            await this.managerContext.AddAsync(user);
            await this.managerContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task Delete(int userId)
        {
            User user = this.managerContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentNullException("The user does not exist!");
            }

            this.managerContext.Users.Remove(user);
            await this.managerContext.SaveChangesAsync();
        }

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

        public User GetByUsername(string username)
        {
            User user = this.managerContext
                .Users
                .FirstOrDefault(u => u.UserName.Any(un => u.UserName == username));
            return user;
        }

        public async Task Update(UpdateUserInputModel inputModel)
        {
            User user = this.managerContext.Users.FirstOrDefault(u => u.Id == inputModel.Id);
            if (user == null)
            {
                throw new ArgumentNullException("Counld not be updated!");
            }

            user.UserName = inputModel.UserName;
            user.Password = inputModel.Password;
            user.FirstName = inputModel.FirstName;
            user.Surname = inputModel.Surname;
            user.Role = inputModel.Role;
            user.Team = inputModel.Team;

            await this.managerContext.SaveChangesAsync();
        }
    }
}

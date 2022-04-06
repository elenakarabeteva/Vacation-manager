using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public class TeamsServices : ITeamsServices
    {
        private readonly VacationManagerContext managerContext;

        public TeamsServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public IEnumerable<User> GetAllTeamDevelopers(Team team)
        {
            var list = this.managerContext
                .Users
                .Where(u => u.Team == team)
                //  .Select(u => u.Role.Type == "Developer")
                .ToList();

            return list;
        }

        public IEnumerable<Team> GetTeamByLeader(User user)
        {
            var leader = this.managerContext
                .Teams
                .Where(t => t.Users == user);

            return leader;
        }

        public IEnumerable<Team> GetTeamByProjectName(string projectTeamName)
        {
            var list = this.managerContext
                .Teams
                .Where(t => t.ProjectTeams.Any(x => x.Project.Name == projectTeamName))
                .ToList();

            return list;
        }

        public Team GetTeamByTeamName(string teamName)
        {
            return this.managerContext.Teams.FirstOrDefault(t => t.Name == teamName);
        }
    }
}

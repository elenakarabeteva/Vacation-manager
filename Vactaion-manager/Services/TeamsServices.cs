using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;
using Vactaion_manager.Models.Teams;

namespace Vactaion_manager.Services
{
    public class TeamsServices : ITeamsServices
    {
        private readonly VacationManagerContext managerContext;

        public TeamsServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public async Task<int> Create(int leaderId, CreateTeamInputModel inputModel)
        {
            User leader = this.managerContext.Users.FirstOrDefault(u => u.Id == leaderId);
            if (leader == null)
            {
                throw new ArgumentNullException("Couldn not find any users!");
            }

            Team team = new Team()
            {
                Name = inputModel.Name,
                Leader = leader,
            };

            await this.managerContext.AddAsync(team);
            await this.managerContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task Delete(int teamId)
        {
            Team team = this.managerContext.Teams.FirstOrDefault(t => t.Id == teamId);
            if (team == null)
            {
                throw new ArgumentNullException("The user does not exist!");
            }

            this.managerContext.Teams.Remove(team);
            await this.managerContext.SaveChangesAsync();
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

        public async Task Update(UpdateTeamInputModel inputModel)
        {
            Team team = this.managerContext.Teams.FirstOrDefault(t => t.Id == inputModel.Id);
            if (team == null)
            {
                throw new ArgumentNullException("Counld not be updated!");
            }

            team.Name = inputModel.Name;
            team.LeaderId = inputModel.LeaderId;

            await this.managerContext.SaveChangesAsync();
        }
    }
}

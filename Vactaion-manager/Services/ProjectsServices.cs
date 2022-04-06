using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public class ProjectsServices : IProjectsServices
    {
        private readonly VacationManagerContext managerContext;

        public ProjectsServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public IEnumerable<Project> GetAllProjectsByDescription(string projectDescription)
        {
            var list = this.managerContext
                .Projects
                .Where(p => p.Description == projectDescription)
                .ToList();

            return list;
        }

        public IEnumerable<Project> GetAllProjectsByName(string projectName)
        {
            var list = this.managerContext
                .Projects
                .Where(p => p.Name == projectName)
                .ToList();

            return list;
        }

        public IEnumerable<Team> GetAllTeamsWorkingOnProject(ProjectTeam projectTeam)
        {
            var list = this.managerContext
                .Teams
                .Where(t => t.ProjectTeams.Contains(projectTeam))
                .ToList();

            return list;
        }
    }
}

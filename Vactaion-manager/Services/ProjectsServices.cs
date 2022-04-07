using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;
using Vactaion_manager.Models.Projects;

namespace Vactaion_manager.Services
{
    public class ProjectsServices : IProjectsServices
    {
        private readonly VacationManagerContext managerContext;

        public ProjectsServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public async Task<int> Create(CreateProjectInputModel inputModel)
        {
            Project project = new Project()
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
            };

            await this.managerContext.AddAsync(project);
            await this.managerContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task Delete(int projectId)
        {
            Project project = this.managerContext.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project == null)
            {
                throw new ArgumentNullException("The user does not exist!");
            }

            this.managerContext.Projects.Remove(project);
            await this.managerContext.SaveChangesAsync();
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

        public async Task Update(UpdateProjectsInputModel inputModel)
        {
            Project project = this.managerContext.Projects.FirstOrDefault(p => p.Id == inputModel.Id);
            if (project == null)
            {
                throw new ArgumentNullException("Counld not be updated!");
            }

            project.Name = inputModel.Name;
            project.Description = inputModel.Description;

            await this.managerContext.SaveChangesAsync();
        }
    }
}

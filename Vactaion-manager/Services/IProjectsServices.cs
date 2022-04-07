using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;
using Vactaion_manager.Models.Projects;

namespace Vactaion_manager.Services
{
    public interface IProjectsServices
    {
        IEnumerable<Project> GetAllProjectsByName(string projectName);

        IEnumerable<Project> GetAllProjectsByDescription(string projectDescription);

        IEnumerable<Team> GetAllTeamsWorkingOnProject(ProjectTeam projectTeam);

        Task<int> Create(CreateProjectInputModel inputModel);

        Task Delete(int projectId);

        Task Update(UpdateProjectsInputModel inputModel);
    }
}

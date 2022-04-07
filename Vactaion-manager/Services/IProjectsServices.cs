﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public interface IProjectsServices
    {
        IEnumerable<Project> GetAllProjectsByName(string projectName);

        IEnumerable<Project> GetAllProjectsByDescription(string projectDescription);

        IEnumerable<Team> GetAllTeamsWorkingOnProject(ProjectTeam projectTeam);

        //filter by name and description
        //detail - list with teams working on it
        //option - add / remove team - controllers

        Task<int> Create(string projectName, string projectDescription);

        Task Delete(int projectId);

        Task Update(string projectName, string projectDescription);
    }
}

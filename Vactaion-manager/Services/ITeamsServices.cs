﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public interface ITeamsServices
    {
        //filter by project name or teams name
        IEnumerable<Team> GetTeamByProjectName(string projectName);
        Team GetTeamByTeamName(string teamName);

        //all developers, who is the leader and
        //full info about the team
        //remove, add user - controller

        IEnumerable<User> GetAllTeamDevelopers(Team team);

        IEnumerable<Team> GetTeamByLeader(User user);


        //IEnumerable<User> GetAllByUsers(string lastName);


    }
}

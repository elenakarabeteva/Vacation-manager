using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Services
{
    public interface ITeamsServices
    {
        //filter by project name or teams name

        //all developers, who is the leader and
        //full info about the team
        //remove, add user
        Team GetByName(string name);

        IEnumerable<Team> GetTeamByLeader(User user);

        //IEnumerable<User> GetAllByUsers(string lastName);

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Services
{
    public class TeamsServices : ITeamsServices
    {
        private readonly VacationManagerContext managerContext;

        public TeamsServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public IEnumerable<Team> GetTeamByLeader(User user)
        {
            var leader = this.managerContext
                .Team
                .Where(t => t.User == user);

            return leader;
        }
    }
}

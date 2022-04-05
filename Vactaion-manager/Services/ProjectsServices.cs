using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Services
{
    public class ProjectsServices
    {
        private readonly VacationManagerContext managerContext;

        public ProjectsServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }
    }
}

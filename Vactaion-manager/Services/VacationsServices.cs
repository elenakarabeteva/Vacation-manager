using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Services
{
    public class VacationsServices
    {
        private readonly VacationManagerContext managerContext;

        public VacationServices(VacationManagerContext managerContext)
        {
            this.managerContext = managerContext;
        }

        public IEnumerable<Vacation> GetAllByType(Type type)
        {
            var list = this.managerContext
                .Vacations
                .OrderBy(v => v.Id)
                .Where(v => v.Type == type)
                .Select(v => new Vacation
                {
                    Id = v.Id,
                    Description = v.Description,
                    StartDate = v.StartDate,
                    EndDate = v.EndDate,
                    CreationDate = v.CreationDate,
                    HalfDateVacation = v.HalfDateVacation,
                    Accepted = v.Accepted
                })
                .ToList();

            return list;
        }

        public IEnumerable<Vacation> GetAllByData(DateTime creationDate)
        {
            var list = this.managerContext
                .Vacations
                .OrderBy(v => v.Id)
                .Where(v => v.CreationDate == creationDate)
                .Select(u => new Vacation
                {
                    Id = v.Id,
                    Description = v.Description,
                    StartDate = v.StartDate,
                    EndDate = v.EndDate,
                    CreationDate = v.CreationDate,
                    HalfDateVacation = v.HalfDateVacation,
                    Accepted = v.Accepted
                })
                .ToList();

            return list;
        }
    }
}

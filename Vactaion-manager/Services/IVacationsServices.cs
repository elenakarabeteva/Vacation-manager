using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;
using Vactaion_manager.Models.Vacations;

namespace Vactaion_manager.Services
{
    public interface IVacationsServices
    {
        IEnumerable<Vacation> GetAllByType(Type type);

        IEnumerable<Vacation> GetAllByData(DateTime creationDate);

        Task<int> Create(int creatorId, int typeId, CreateVacationInputModel inputModel);

        Task Delete(int vacationId);

        Task Update(UpdateVacationInputModel inputModel);
    }
}

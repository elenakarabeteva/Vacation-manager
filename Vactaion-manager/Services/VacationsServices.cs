using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;
using Vactaion_manager.Models.Vacations;

namespace Vactaion_manager.Services
{
    public class VacationsServices : IVacationsServices
    {
        private readonly VacationManagerContext managerContext;

        public VacationsServices(VacationManagerContext managerContext)
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
                    HalfADayVacation = v.HalfADayVacation,
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
                .Select(v => new Vacation
                {
                    Id = v.Id,
                    Description = v.Description,
                    StartDate = v.StartDate,
                    EndDate = v.EndDate,
                    CreationDate = v.CreationDate,
                    HalfADayVacation = v.HalfADayVacation,
                    Accepted = v.Accepted
                })
                .ToList();

            return list;
        }

        public async Task<int> Create(int creatorId, int typeId, CreateVacationInputModel inputModel)
        {
            User user = this.managerContext.Users.FirstOrDefault(u => u.Id == creatorId);
            VacationType type = this.managerContext.VacationTypes.FirstOrDefault(v => v.Id == typeId);

            if (user == null || type == null)
            {
                throw new ArgumentNullException("Couldn not be expty!");
            }

            Vacation vacation = new Vacation()
            {
                Description = inputModel.Description,
                StartDate = inputModel.StartDate,
                EndDate = inputModel.EndDate,
                HalfADayVacation = inputModel.HalfADayVacation,
                Accepted = inputModel.Accepted,
                user = user,
            };

            await this.managerContext.AddAsync(vacation);
            await this.managerContext.SaveChangesAsync();

            return vacation.Id;
        }

        public async Task Delete(int vacationId)
        {
            Vacation vacation = this.managerContext.Vacations.FirstOrDefault(v => v.Id == vacationId);
            if (vacation == null)
            {
                throw new ArgumentNullException("The vacation does not exist!");
            }

            if (vacation.Accepted == true)
            {
                throw new InvalidOperationException("The vacation is accepted");
            }

            this.managerContext.Vacations.Remove(vacation);
            await this.managerContext.SaveChangesAsync();
        }

        public async Task Update(UpdateVacationInputModel inputModel)
        {
            Vacation vacation = this.managerContext.Vacations.FirstOrDefault(v => v.Id == inputModel.Id);
            if (vacation == null)
            {
                throw new ArgumentNullException("Counld not be updated!");
            }

            vacation.Description = inputModel.Description;
            vacation.EndDate = inputModel.EndDate;
            vacation.Accepted = inputModel.Accepted;
            vacation.StartDate = inputModel.StartDate;
            vacation.HalfADayVacation = inputModel.HalfADayVacation;

            await this.managerContext.SaveChangesAsync();
        }
    }
}

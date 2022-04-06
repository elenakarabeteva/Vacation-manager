using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Services
{
    public interface IVacationsServices
    {
        // Vacation GetByType(Type type);

        IEnumerable<Vacation> GetAllByType(Type type);

        IEnumerable<Vacation> GetAllByData(DateTime creationDate);

        //see all
        //delete - controller
        //download - controller
        //filter by data
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Services
{
    public interface IVacationsServices
    {
       // Vacation GetByType(Type type);

        IEnumerable<Vacation> GetAllByType(Type type);

        IEnumerable<Vacation> GetAllByData(DateTime creationDate);
        //see all
        //delete
        //download
        //filter by data
    }
}

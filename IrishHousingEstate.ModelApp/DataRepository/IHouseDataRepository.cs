using IrishHousingEstate.ModelApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IrishHousingEstate.ModelApp.DataRepository
{
    public interface IHouseDataRepository
    {
        Task<IEnumerable<HouseDataModel>> GetAllRecords();
    }
}

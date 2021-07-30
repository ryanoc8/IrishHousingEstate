using IrishHousingEstate.ModelApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IrishHousingEstate.ModelApp.DataRepository
{
    public interface IHouseDataRepository
    {
        Task<int> AddRecord(HouseData houseData);
        Task<IEnumerable<HouseData>> GetAllRecords();
        Task<HouseData> GetRecordById(int id);
        void DeleteRecord(int id);
        void UpdateRecord(HouseData houseData);
        int SaveChanges();
    }
}

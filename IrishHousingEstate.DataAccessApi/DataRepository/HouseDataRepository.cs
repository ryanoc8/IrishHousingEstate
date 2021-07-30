using IrishHousingEstate.DataAccessApi.DBContext;
using IrishHousingEstate.ModelApp.DataRepository;
using IrishHousingEstate.ModelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrishHousingEstate.DataAccessApi.DataRepository
{
    public class HouseDataRepository : IHouseDataRepository
    {
        private readonly IrishHousingEstateDbContext dbctx;

        public HouseDataRepository(IrishHousingEstateDbContext dbctx) => this.dbctx = dbctx;

        public async Task<int> AddRecord(HouseData houseData)
        {
            await this.dbctx.AddAsync(houseData);
            int result = this.dbctx.SaveChanges();
            return result;
        }

        public async Task<IEnumerable<HouseData>> GetAllRecords()
        {
            return await this.dbctx.HouseDataModel.OrderBy(x => x.Id).AsNoTracking().ToListAsync();
        }

        public async Task<HouseData> GetRecordById(int id)
        {
            return await this.dbctx.HouseDataModel.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public void DeleteRecord(int id)
        {
            var record = this.dbctx.HouseDataModel.Where(x => x.Id == id).First();
            this.dbctx.Remove(record);
            this.dbctx.SaveChanges();
        }

        public void UpdateRecord(HouseData houseData)
        {
            //var record = await this.dbctx.HouseDataModel.Where(x => x.Id == id).FirstAsync();
            this.dbctx.Update(houseData);
            this.dbctx.SaveChanges();
        }

        public int SaveChanges() => this.dbctx.SaveChanges();
    }
}

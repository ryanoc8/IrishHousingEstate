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

        public HouseDataRepository(IrishHousingEstateDbContext dbctx)
        {
            this.dbctx = dbctx;
        }

        public async Task<IEnumerable<HouseDataModel>> GetAllRecords()
        {
            return await this.dbctx.HouseDataModels.OrderBy(x => x.Id).AsNoTracking().ToListAsync();
        }
    }
}

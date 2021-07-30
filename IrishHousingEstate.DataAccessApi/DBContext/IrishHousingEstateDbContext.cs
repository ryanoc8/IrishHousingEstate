using IrishHousingEstate.ModelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace IrishHousingEstate.DataAccessApi.DBContext
{
    public class IrishHousingEstateDbContext : DbContext
    {
        public DbSet<HouseData> HouseDataModel { get; set; }

        public IrishHousingEstateDbContext() : base() { }

        public IrishHousingEstateDbContext(DbContextOptions<IrishHousingEstateDbContext> options) : base(options) { }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IrishHousingEstate.ServiceApi.Migrations
{
    public partial class InitialIrishHousingEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseDataModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaGroupEffect = table.Column<int>(nullable: false),
                    County = table.Column<string>(nullable: true),
                    CountyEffect = table.Column<int>(nullable: false),
                    PropertySizeSquareMeters = table.Column<int>(nullable: false),
                    PropertySizeEffect = table.Column<int>(nullable: false),
                    YearBuild = table.Column<string>(nullable: true),
                    BerRating = table.Column<string>(nullable: true),
                    NumberOfBedrooms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDataModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseDataModel");
        }
    }
}

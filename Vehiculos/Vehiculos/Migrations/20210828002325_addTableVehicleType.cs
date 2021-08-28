using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehiculos.Migrations
{
    public partial class addTableVehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiculeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiculeTypes_Description",
                table: "VehiculeTypes",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculeTypes");
        }
    }
}

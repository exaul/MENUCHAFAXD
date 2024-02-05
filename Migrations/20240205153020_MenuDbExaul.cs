using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TODOLOQUEPUEDASCOMER.Migrations
{
    /// <inheritdoc />
    public partial class MenuDbExaul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platillo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bebidas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Bebidas", "Platillo", "Precio" },
                values: new object[,]
                {
                    { 1, "Jugo de naranja", "Salmón a la plancha con arroz y espárragos", "5 $" },
                    { 2, "Chai", "Anguila teriyaki con sésamo", "5 $" },
                    { 3, "Coca Cola ", "Solomillo de cordero al horno con costra verde y chalotas", "5 $" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}

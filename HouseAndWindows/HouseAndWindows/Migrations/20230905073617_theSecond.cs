using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseAndWindows.Migrations
{
    public partial class theSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "houseId",
                table: "Window",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "houseId",
                table: "Window");
        }
    }
}

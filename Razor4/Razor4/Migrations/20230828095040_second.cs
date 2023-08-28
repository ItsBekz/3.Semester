using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Razor4.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pet",
                table: "Item2",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pet",
                table: "Item2");
        }
    }
}

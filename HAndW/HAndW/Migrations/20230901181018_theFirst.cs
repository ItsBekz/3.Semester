using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HAndW.Migrations
{
    public partial class theFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Window",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<int>(type: "int", nullable: true),
                    Houseid = table.Column<int>(type: "int", nullable: true),
                    Windowid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Window", x => x.id);
                    table.ForeignKey(
                        name: "FK_Window_House_Houseid",
                        column: x => x.Houseid,
                        principalTable: "House",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Window_Window_Windowid",
                        column: x => x.Windowid,
                        principalTable: "Window",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Window_Houseid",
                table: "Window",
                column: "Houseid");

            migrationBuilder.CreateIndex(
                name: "IX_Window_Windowid",
                table: "Window",
                column: "Windowid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Window");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}

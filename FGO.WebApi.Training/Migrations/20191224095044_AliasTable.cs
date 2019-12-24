using Microsoft.EntityFrameworkCore.Migrations;

namespace FGO.WebApi.Training.Migrations
{
    public partial class AliasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Servants");

            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(nullable: true),
                    ServantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliases_Servants_ServantId",
                        column: x => x.ServantId,
                        principalTable: "Servants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_ServantId",
                table: "Aliases",
                column: "ServantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Servants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

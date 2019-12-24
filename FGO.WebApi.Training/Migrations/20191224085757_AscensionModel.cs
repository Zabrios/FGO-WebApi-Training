using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FGO.WebApi.Training.Migrations
{
    public partial class AscensionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServantAscensionsServantID",
                table: "Servants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServantAscensions",
                columns: table => new
                {
                    ServantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServantAscensions", x => x.ServantID);
                });

            migrationBuilder.CreateTable(
                name: "Ascensions",
                columns: table => new
                {
                    ServantID = table.Column<int>(nullable: false),
                    AscensionID = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    ServantAscensionModelServantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ascensions", x => new { x.ServantID, x.AscensionID });
                    table.ForeignKey(
                        name: "FK_Ascensions_ServantAscensions_ServantAscensionModelServantID",
                        column: x => x.ServantAscensionModelServantID,
                        principalTable: "ServantAscensions",
                        principalColumn: "ServantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servants_ServantAscensionsServantID",
                table: "Servants",
                column: "ServantAscensionsServantID");

            migrationBuilder.CreateIndex(
                name: "IX_Ascensions_ServantAscensionModelServantID",
                table: "Ascensions",
                column: "ServantAscensionModelServantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Servants_ServantAscensions_ServantAscensionsServantID",
                table: "Servants",
                column: "ServantAscensionsServantID",
                principalTable: "ServantAscensions",
                principalColumn: "ServantID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servants_ServantAscensions_ServantAscensionsServantID",
                table: "Servants");

            migrationBuilder.DropTable(
                name: "Ascensions");

            migrationBuilder.DropTable(
                name: "ServantAscensions");

            migrationBuilder.DropIndex(
                name: "IX_Servants_ServantAscensionsServantID",
                table: "Servants");

            migrationBuilder.DropColumn(
                name: "ServantAscensionsServantID",
                table: "Servants");
        }
    }
}

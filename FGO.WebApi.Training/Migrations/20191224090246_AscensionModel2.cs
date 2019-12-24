using Microsoft.EntityFrameworkCore.Migrations;

namespace FGO.WebApi.Training.Migrations
{
    public partial class AscensionModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ascensions_ServantAscensions_ServantAscensionModelServantID",
                table: "Ascensions");

            migrationBuilder.DropForeignKey(
                name: "FK_Servants_ServantAscensions_ServantAscensionsServantID",
                table: "Servants");

            migrationBuilder.DropTable(
                name: "ServantAscensions");

            migrationBuilder.DropIndex(
                name: "IX_Servants_ServantAscensionsServantID",
                table: "Servants");

            migrationBuilder.DropIndex(
                name: "IX_Ascensions_ServantAscensionModelServantID",
                table: "Ascensions");

            migrationBuilder.DropColumn(
                name: "ServantAscensionsServantID",
                table: "Servants");

            migrationBuilder.DropColumn(
                name: "ServantAscensionModelServantID",
                table: "Ascensions");

            migrationBuilder.AddColumn<int>(
                name: "ServantBaseModelID",
                table: "Ascensions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ascensions_ServantBaseModelID",
                table: "Ascensions",
                column: "ServantBaseModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ascensions_Servants_ServantBaseModelID",
                table: "Ascensions",
                column: "ServantBaseModelID",
                principalTable: "Servants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ascensions_Servants_ServantBaseModelID",
                table: "Ascensions");

            migrationBuilder.DropIndex(
                name: "IX_Ascensions_ServantBaseModelID",
                table: "Ascensions");

            migrationBuilder.DropColumn(
                name: "ServantBaseModelID",
                table: "Ascensions");

            migrationBuilder.AddColumn<int>(
                name: "ServantAscensionsServantID",
                table: "Servants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServantAscensionModelServantID",
                table: "Ascensions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServantAscensions",
                columns: table => new
                {
                    ServantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServantAscensions", x => x.ServantID);
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
                name: "FK_Ascensions_ServantAscensions_ServantAscensionModelServantID",
                table: "Ascensions",
                column: "ServantAscensionModelServantID",
                principalTable: "ServantAscensions",
                principalColumn: "ServantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servants_ServantAscensions_ServantAscensionsServantID",
                table: "Servants",
                column: "ServantAscensionsServantID",
                principalTable: "ServantAscensions",
                principalColumn: "ServantID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

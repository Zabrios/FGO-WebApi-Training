using Microsoft.EntityFrameworkCore.Migrations;

namespace FGO.WebApi.Training.Migrations
{
    public partial class AscensionRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ascensions_Servants_ServantBaseModelID",
                table: "Ascensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ascensions",
                table: "Ascensions");

            migrationBuilder.DropIndex(
                name: "IX_Ascensions_ServantBaseModelID",
                table: "Ascensions");

            migrationBuilder.DropColumn(
                name: "AscensionID",
                table: "Ascensions");

            migrationBuilder.DropColumn(
                name: "ServantBaseModelID",
                table: "Ascensions");

            migrationBuilder.RenameColumn(
                name: "ServantID",
                table: "Ascensions",
                newName: "ServantId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ascensions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ascensions",
                table: "Ascensions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ascensions_ServantId",
                table: "Ascensions",
                column: "ServantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ascensions_Servants_ServantId",
                table: "Ascensions",
                column: "ServantId",
                principalTable: "Servants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ascensions_Servants_ServantId",
                table: "Ascensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ascensions",
                table: "Ascensions");

            migrationBuilder.DropIndex(
                name: "IX_Ascensions_ServantId",
                table: "Ascensions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ascensions");

            migrationBuilder.RenameColumn(
                name: "ServantId",
                table: "Ascensions",
                newName: "ServantID");

            migrationBuilder.AddColumn<int>(
                name: "AscensionID",
                table: "Ascensions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServantBaseModelID",
                table: "Ascensions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ascensions",
                table: "Ascensions",
                columns: new[] { "ServantID", "AscensionID" });

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
    }
}

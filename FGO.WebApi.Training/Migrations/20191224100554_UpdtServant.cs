using Microsoft.EntityFrameworkCore.Migrations;

namespace FGO.WebApi.Training.Migrations
{
    public partial class UpdtServant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommandCards",
                table: "Servants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommandCards",
                table: "Servants");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FGO.WebApi.Training.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    ServantClass = table.Column<string>(nullable: true),
                    MaxLvl = table.Column<int>(nullable: false),
                    RarityNum = table.Column<int>(nullable: false),
                    RarityName = table.Column<string>(nullable: true),
                    AtkLv1 = table.Column<int>(nullable: false),
                    AtkMaxLv = table.Column<int>(nullable: false),
                    AtkLv100 = table.Column<int>(nullable: false),
                    HpLv1 = table.Column<int>(nullable: false),
                    HpMaxLv = table.Column<int>(nullable: false),
                    HpLv100 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servants", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servants");
        }
    }
}

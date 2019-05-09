using Microsoft.EntityFrameworkCore.Migrations;

namespace NPV.DatabaseCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreviousResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LifeOfProject = table.Column<int>(nullable: false),
                    InitialCost = table.Column<decimal>(nullable: false),
                    LowerBoundDiscountRate = table.Column<double>(nullable: false),
                    UpperBoundDiscountRate = table.Column<double>(nullable: false),
                    DiscountRateIncrement = table.Column<double>(nullable: false),
                    NetPresentValue = table.Column<decimal>(nullable: false),
                    PresentValueOfCashFlows = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviousResults");
        }
    }
}

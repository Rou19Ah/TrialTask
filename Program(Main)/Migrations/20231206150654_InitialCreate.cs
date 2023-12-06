using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Program_Main_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lasers",
                columns: table => new
                {
                    LaserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LaserName = table.Column<string>(type: "TEXT", nullable: false),
                    MaximumPower = table.Column<decimal>(type: "TEXT", nullable: false),
                    MaximumWeldingDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfTriggeredWelds = table.Column<int>(type: "INTEGER", nullable: false),
                    ConsumedEnergy = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lasers", x => x.LaserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lasers");
        }
    }
}

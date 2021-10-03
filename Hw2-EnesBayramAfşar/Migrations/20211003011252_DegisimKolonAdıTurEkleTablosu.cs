using Microsoft.EntityFrameworkCore.Migrations;

namespace Hw2_EnesBayramAfşar.Migrations
{
    public partial class DegisimKolonAdıTurEkleTablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Turler",
                newName: "TurAd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TurAd",
                table: "Turler",
                newName: "Ad");
        }
    }
}

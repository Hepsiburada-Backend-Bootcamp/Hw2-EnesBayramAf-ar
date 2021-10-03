using Microsoft.EntityFrameworkCore.Migrations;

namespace Hw2_EnesBayramAfşar.Migrations
{
    public partial class EkleBirebirİliskiKitapDetay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitapDetayId",
                table: "tb_Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KitapDetay",
                columns: table => new
                {
                    KitapDetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    KitapSayfasi = table.Column<int>(type: "int", nullable: false),
                    KitapAgirlik = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapDetay", x => x.KitapDetayId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kitap_KitapDetayId",
                table: "tb_Kitap",
                column: "KitapDetayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Kitap_KitapDetay_KitapDetayId",
                table: "tb_Kitap",
                column: "KitapDetayId",
                principalTable: "KitapDetay",
                principalColumn: "KitapDetayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Kitap_KitapDetay_KitapDetayId",
                table: "tb_Kitap");

            migrationBuilder.DropTable(
                name: "KitapDetay");

            migrationBuilder.DropIndex(
                name: "IX_tb_Kitap_KitapDetayId",
                table: "tb_Kitap");

            migrationBuilder.DropColumn(
                name: "KitapDetayId",
                table: "tb_Kitap");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Hw2_EnesBayramAfşar.Migrations
{
    public partial class EkleİliskiKitapKategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "tb_Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kitap_KategoriId",
                table: "tb_Kitap",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Kitap_Kategoriler_KategoriId",
                table: "tb_Kitap",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Kitap_Kategoriler_KategoriId",
                table: "tb_Kitap");

            migrationBuilder.DropIndex(
                name: "IX_tb_Kitap_KategoriId",
                table: "tb_Kitap");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "tb_Kitap");
        }
    }
}

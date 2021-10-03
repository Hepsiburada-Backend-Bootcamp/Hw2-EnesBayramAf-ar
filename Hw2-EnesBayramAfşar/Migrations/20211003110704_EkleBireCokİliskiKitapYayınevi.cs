using Microsoft.EntityFrameworkCore.Migrations;

namespace Hw2_EnesBayramAfşar.Migrations
{
    public partial class EkleBireCokİliskiKitapYayınevi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YayınEviId",
                table: "tb_Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kitap_YayınEviId",
                table: "tb_Kitap",
                column: "YayınEviId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Kitap_tb_YayinEvi_YayınEviId",
                table: "tb_Kitap",
                column: "YayınEviId",
                principalTable: "tb_YayinEvi",
                principalColumn: "YayinEvi_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Kitap_tb_YayinEvi_YayınEviId",
                table: "tb_Kitap");

            migrationBuilder.DropIndex(
                name: "IX_tb_Kitap_YayınEviId",
                table: "tb_Kitap");

            migrationBuilder.DropColumn(
                name: "YayınEviId",
                table: "tb_Kitap");
        }
    }
}

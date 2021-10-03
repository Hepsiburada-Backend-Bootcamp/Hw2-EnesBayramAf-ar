using Microsoft.EntityFrameworkCore.Migrations;

namespace Hw2_EnesBayramAfşar.Migrations
{
    public partial class EkleCoktanCokaIlıskıKItapYazar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KitapYazarlar",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    Yazar_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazarlar", x => new { x.Yazar_Id, x.KitapId });
                    table.ForeignKey(
                        name: "FK_KitapYazarlar_tb_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "tb_Kitap",
                        principalColumn: "KitapId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazarlar_tb_Yazar_Yazar_Id",
                        column: x => x.Yazar_Id,
                        principalTable: "tb_Yazar",
                        principalColumn: "Yazar_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazarlar_KitapId",
                table: "KitapYazarlar",
                column: "KitapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapYazarlar");
        }
    }
}

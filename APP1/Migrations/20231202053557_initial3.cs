using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP1.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tramites_areas_DestinoId",
                table: "tramites");

            migrationBuilder.DropIndex(
                name: "IX_tramites_DestinoId",
                table: "tramites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tramites_DestinoId",
                table: "tramites",
                column: "DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tramites_areas_DestinoId",
                table: "tramites",
                column: "DestinoId",
                principalTable: "areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

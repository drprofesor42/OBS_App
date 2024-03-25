using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBS_App.Migrations
{
    /// <inheritdoc />
    public partial class asdads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bildirimler_Ogrenciler_OgrencisId",
                table: "Bildirimler");

            migrationBuilder.DropForeignKey(
                name: "FK_Bildirimler_Ogretmenler_OgretmensId",
                table: "Bildirimler");

            migrationBuilder.DropIndex(
                name: "IX_Bildirimler_OgrencisId",
                table: "Bildirimler");

            migrationBuilder.DropIndex(
                name: "IX_Bildirimler_OgretmensId",
                table: "Bildirimler");

            migrationBuilder.DropColumn(
                name: "OgrencisId",
                table: "Bildirimler");

            migrationBuilder.DropColumn(
                name: "OgretmensId",
                table: "Bildirimler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgrencisId",
                table: "Bildirimler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OgretmensId",
                table: "Bildirimler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bildirimler_OgrencisId",
                table: "Bildirimler",
                column: "OgrencisId");

            migrationBuilder.CreateIndex(
                name: "IX_Bildirimler_OgretmensId",
                table: "Bildirimler",
                column: "OgretmensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bildirimler_Ogrenciler_OgrencisId",
                table: "Bildirimler",
                column: "OgrencisId",
                principalTable: "Ogrenciler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bildirimler_Ogretmenler_OgretmensId",
                table: "Bildirimler",
                column: "OgretmensId",
                principalTable: "Ogretmenler",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEduApp.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EgitimModulleri",
                columns: table => new
                {
                    EgitimModulId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModulAdi = table.Column<string>(type: "TEXT", nullable: true),
                    Sure = table.Column<int>(type: "INTEGER", nullable: false),
                    Seviye = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimModulleri", x => x.EgitimModulId);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdSoyad = table.Column<string>(type: "TEXT", nullable: true),
                    Bolum = table.Column<string>(type: "TEXT", nullable: true),
                    AktiflikDurumu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performanslar",
                columns: table => new
                {
                    PerformansId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrtalamaNot = table.Column<int>(type: "INTEGER", nullable: false),
                    DevamYuzdesi = table.Column<int>(type: "INTEGER", nullable: false),
                    BasariSeviyesi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performanslar", x => x.PerformansId);
                });

            migrationBuilder.CreateTable(
                name: "EgitimKayitlari",
                columns: table => new
                {
                    KayitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OgrenciId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModulId = table.Column<int>(type: "INTEGER", nullable: false),
                    EgitimModulId = table.Column<int>(type: "INTEGER", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimKayitlari", x => x.KayitId);
                    table.ForeignKey(
                        name: "FK_EgitimKayitlari_EgitimModulleri_EgitimModulId",
                        column: x => x.EgitimModulId,
                        principalTable: "EgitimModulleri",
                        principalColumn: "EgitimModulId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EgitimKayitlari_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EgitimKayitlari_EgitimModulId",
                table: "EgitimKayitlari",
                column: "EgitimModulId");

            migrationBuilder.CreateIndex(
                name: "IX_EgitimKayitlari_OgrenciId",
                table: "EgitimKayitlari",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EgitimKayitlari");

            migrationBuilder.DropTable(
                name: "Performanslar");

            migrationBuilder.DropTable(
                name: "EgitimModulleri");

            migrationBuilder.DropTable(
                name: "Ogrenciler");
        }
    }
}

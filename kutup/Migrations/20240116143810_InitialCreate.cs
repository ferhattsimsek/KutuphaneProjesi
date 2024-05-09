using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kutup.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategoriAdi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KitapAdi = table.Column<string>(type: "TEXT", nullable: true),
                    Hakkında = table.Column<string>(type: "TEXT", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    UserLastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Tel = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıId);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    YazarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YazarAdi = table.Column<string>(type: "TEXT", nullable: true),
                    YazarSoyadi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.YazarId);
                });

            migrationBuilder.CreateTable(
                name: "KategoriKitap",
                columns: table => new
                {
                    KategorilerKategoriId = table.Column<int>(type: "INTEGER", nullable: false),
                    KitaplarISBN = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriKitap", x => new { x.KategorilerKategoriId, x.KitaplarISBN });
                    table.ForeignKey(
                        name: "FK_KategoriKitap_Kategoriler_KategorilerKategoriId",
                        column: x => x.KategorilerKategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriKitap_Kitaplar_KitaplarISBN",
                        column: x => x.KitaplarISBN,
                        principalTable: "Kitaplar",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emanetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KitapId = table.Column<int>(type: "INTEGER", nullable: false),
                    KullanıcıId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlisTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GetirecegiTarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GetirdiğiTarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KalanGünSayısı = table.Column<int>(type: "INTEGER", nullable: false),
                    getirdimi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emanetler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emanetler_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emanetler_Kullanıcılar_KullanıcıId",
                        column: x => x.KullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KitapISBN = table.Column<int>(type: "INTEGER", nullable: false),
                    KullanıcıId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kitaplar_KitapISBN",
                        column: x => x.KitapISBN,
                        principalTable: "Kitaplar",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kullanıcılar_KullanıcıId",
                        column: x => x.KullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapYazar",
                columns: table => new
                {
                    KitaplarISBN = table.Column<int>(type: "INTEGER", nullable: false),
                    YazarlarYazarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazar", x => new { x.KitaplarISBN, x.YazarlarYazarId });
                    table.ForeignKey(
                        name: "FK_KitapYazar_Kitaplar_KitaplarISBN",
                        column: x => x.KitaplarISBN,
                        principalTable: "Kitaplar",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Yazarlar_YazarlarYazarId",
                        column: x => x.YazarlarYazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "YazarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emanetler_KitapId",
                table: "Emanetler",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_Emanetler_KullanıcıId",
                table: "Emanetler",
                column: "KullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriKitap_KitaplarISBN",
                table: "KategoriKitap",
                column: "KitaplarISBN");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_YazarlarYazarId",
                table: "KitapYazar",
                column: "YazarlarYazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KitapISBN",
                table: "Yorumlar",
                column: "KitapISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KullanıcıId",
                table: "Yorumlar",
                column: "KullanıcıId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emanetler");

            migrationBuilder.DropTable(
                name: "KategoriKitap");

            migrationBuilder.DropTable(
                name: "KitapYazar");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Yazarlar");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");
        }
    }
}

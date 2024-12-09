﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RIIMS1.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseRiimsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gjuhet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmriGjuhes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gjuhet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institucioni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institucioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiveliAkademik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lvl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveliAkademik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiveliGjuhesor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Niveli = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveliGjuhesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamenti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamenti_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mbiemri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gjinia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataELindjes = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numriTelefonit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NiveliAkademikId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_NiveliAkademik_NiveliAkademikId",
                        column: x => x.NiveliAkademikId,
                        principalTable: "NiveliAkademik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aftesite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aftesite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aftesite_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aftesite_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edukimi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FushaStudimit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFillimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMbarimit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NiveliAkademikId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edukimi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edukimi_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Edukimi_NiveliAkademik_NiveliAkademikId",
                        column: x => x.NiveliAkademikId,
                        principalTable: "NiveliAkademik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edukimi_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eksperienca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LlojiPunesimit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LlojiLokacionit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFillimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMbarimit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eksperienca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eksperienca_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eksperienca_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HonorsAndAwards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataEleshimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HonorsAndAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HonorsAndAwards_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HonorsAndAwards_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licensat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLeshimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSkadimit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CredentialId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CredentialUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licensat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licensat_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licensat_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MbikqyresITemave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulliTemes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studenti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    DepartamentiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MbikqyresITemave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MbikqyresITemave_Departamenti_DepartamentiId",
                        column: x => x.DepartamentiId,
                        principalTable: "Departamenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MbikqyresITemave_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projekti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emriProjektit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    collaborators = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekti_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekti_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publikimi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LlojiPublikimit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkuPublikimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoriKryesor = table.Column<bool>(type: "bit", nullable: true),
                    DataPublikimi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    DepartamentiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publikimi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publikimi_Departamenti_DepartamentiId",
                        column: x => x.DepartamentiId,
                        principalTable: "Departamenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publikimi_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PunaVullnetare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Roli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFillimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMbarimit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunaVullnetare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PunaVullnetare_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunaVullnetare_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specializimet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    llojiIspecializimit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lokacionit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataEFillimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataEMbarimit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    aftesiteEfituara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nrKredive = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    InstitucioniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializimet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializimet_Institucioni_InstitucioniId",
                        column: x => x.InstitucioniId,
                        principalTable: "Institucioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specializimet_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGjuhet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    GjuhaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NiveliGjuhesorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGjuhet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGjuhet_Gjuhet_GjuhaId",
                        column: x => x.GjuhaId,
                        principalTable: "Gjuhet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGjuhet_NiveliGjuhesor_NiveliGjuhesorId",
                        column: x => x.NiveliGjuhesorId,
                        principalTable: "NiveliGjuhesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGjuhet_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aftesite_InstitucioniId",
                table: "Aftesite",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Aftesite_UserId1",
                table: "Aftesite",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Departamenti_InstitucioniId",
                table: "Departamenti",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Edukimi_InstitucioniId",
                table: "Edukimi",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Edukimi_NiveliAkademikId",
                table: "Edukimi",
                column: "NiveliAkademikId");

            migrationBuilder.CreateIndex(
                name: "IX_Edukimi_UserId1",
                table: "Edukimi",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Eksperienca_InstitucioniId",
                table: "Eksperienca",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Eksperienca_UserId1",
                table: "Eksperienca",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_HonorsAndAwards_InstitucioniId",
                table: "HonorsAndAwards",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_HonorsAndAwards_UserId1",
                table: "HonorsAndAwards",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Licensat_InstitucioniId",
                table: "Licensat",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Licensat_UserId1",
                table: "Licensat",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MbikqyresITemave_DepartamentiId",
                table: "MbikqyresITemave",
                column: "DepartamentiId");

            migrationBuilder.CreateIndex(
                name: "IX_MbikqyresITemave_UserId1",
                table: "MbikqyresITemave",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Projekti_InstitucioniId",
                table: "Projekti",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekti_UserId1",
                table: "Projekti",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Publikimi_DepartamentiId",
                table: "Publikimi",
                column: "DepartamentiId");

            migrationBuilder.CreateIndex(
                name: "IX_Publikimi_UserId1",
                table: "Publikimi",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PunaVullnetare_InstitucioniId",
                table: "PunaVullnetare",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_PunaVullnetare_UserId1",
                table: "PunaVullnetare",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Specializimet_InstitucioniId",
                table: "Specializimet",
                column: "InstitucioniId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializimet_UserId1",
                table: "Specializimet",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_ImageId",
                table: "User",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_NiveliAkademikId",
                table: "User",
                column: "NiveliAkademikId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGjuhet_GjuhaId",
                table: "UserGjuhet",
                column: "GjuhaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGjuhet_NiveliGjuhesorId",
                table: "UserGjuhet",
                column: "NiveliGjuhesorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGjuhet_UserId1",
                table: "UserGjuhet",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aftesite");

            migrationBuilder.DropTable(
                name: "Edukimi");

            migrationBuilder.DropTable(
                name: "Eksperienca");

            migrationBuilder.DropTable(
                name: "HonorsAndAwards");

            migrationBuilder.DropTable(
                name: "Licensat");

            migrationBuilder.DropTable(
                name: "MbikqyresITemave");

            migrationBuilder.DropTable(
                name: "Projekti");

            migrationBuilder.DropTable(
                name: "Publikimi");

            migrationBuilder.DropTable(
                name: "PunaVullnetare");

            migrationBuilder.DropTable(
                name: "Specializimet");

            migrationBuilder.DropTable(
                name: "UserGjuhet");

            migrationBuilder.DropTable(
                name: "Departamenti");

            migrationBuilder.DropTable(
                name: "Gjuhet");

            migrationBuilder.DropTable(
                name: "NiveliGjuhesor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Institucioni");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "NiveliAkademik");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RIIMSAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserIddatatypefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aftesite_User_UserId1",
                table: "Aftesite");

            migrationBuilder.DropForeignKey(
                name: "FK_Edukimi_User_UserId1",
                table: "Edukimi");

            migrationBuilder.DropForeignKey(
                name: "FK_Eksperienca_User_UserId1",
                table: "Eksperienca");

            migrationBuilder.DropForeignKey(
                name: "FK_HonorsAndAwards_User_UserId1",
                table: "HonorsAndAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_Licensat_User_UserId1",
                table: "Licensat");

            migrationBuilder.DropForeignKey(
                name: "FK_MbikqyresITemave_User_UserId1",
                table: "MbikqyresITemave");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekti_User_UserId1",
                table: "Projekti");

            migrationBuilder.DropForeignKey(
                name: "FK_Publikimi_User_UserId1",
                table: "Publikimi");

            migrationBuilder.DropForeignKey(
                name: "FK_PunaVullnetare_User_UserId1",
                table: "PunaVullnetare");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializimet_User_UserId1",
                table: "Specializimet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGjuhet_User_UserId1",
                table: "UserGjuhet");

            migrationBuilder.DropIndex(
                name: "IX_UserGjuhet_UserId1",
                table: "UserGjuhet");

            migrationBuilder.DropIndex(
                name: "IX_Specializimet_UserId1",
                table: "Specializimet");

            migrationBuilder.DropIndex(
                name: "IX_PunaVullnetare_UserId1",
                table: "PunaVullnetare");

            migrationBuilder.DropIndex(
                name: "IX_Publikimi_UserId1",
                table: "Publikimi");

            migrationBuilder.DropIndex(
                name: "IX_Projekti_UserId1",
                table: "Projekti");

            migrationBuilder.DropIndex(
                name: "IX_MbikqyresITemave_UserId1",
                table: "MbikqyresITemave");

            migrationBuilder.DropIndex(
                name: "IX_Licensat_UserId1",
                table: "Licensat");

            migrationBuilder.DropIndex(
                name: "IX_HonorsAndAwards_UserId1",
                table: "HonorsAndAwards");

            migrationBuilder.DropIndex(
                name: "IX_Eksperienca_UserId1",
                table: "Eksperienca");

            migrationBuilder.DropIndex(
                name: "IX_Edukimi_UserId1",
                table: "Edukimi");

            migrationBuilder.DropIndex(
                name: "IX_Aftesite_UserId1",
                table: "Aftesite");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserGjuhet");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Specializimet");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PunaVullnetare");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Publikimi");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Projekti");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MbikqyresITemave");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Licensat");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "HonorsAndAwards");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Eksperienca");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Edukimi");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Aftesite");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserGjuhet",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Specializimet",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PunaVullnetare",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Publikimi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Projekti",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MbikqyresITemave",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Licensat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "HonorsAndAwards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Eksperienca",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Edukimi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Aftesite",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserGjuhet_UserId",
                table: "UserGjuhet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializimet_UserId",
                table: "Specializimet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PunaVullnetare_UserId",
                table: "PunaVullnetare",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publikimi_UserId",
                table: "Publikimi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekti_UserId",
                table: "Projekti",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MbikqyresITemave_UserId",
                table: "MbikqyresITemave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Licensat_UserId",
                table: "Licensat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HonorsAndAwards_UserId",
                table: "HonorsAndAwards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Eksperienca_UserId",
                table: "Eksperienca",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edukimi_UserId",
                table: "Edukimi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Aftesite_UserId",
                table: "Aftesite",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aftesite_User_UserId",
                table: "Aftesite",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Edukimi_User_UserId",
                table: "Edukimi",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eksperienca_User_UserId",
                table: "Eksperienca",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HonorsAndAwards_User_UserId",
                table: "HonorsAndAwards",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licensat_User_UserId",
                table: "Licensat",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MbikqyresITemave_User_UserId",
                table: "MbikqyresITemave",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekti_User_UserId",
                table: "Projekti",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publikimi_User_UserId",
                table: "Publikimi",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PunaVullnetare_User_UserId",
                table: "PunaVullnetare",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializimet_User_UserId",
                table: "Specializimet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGjuhet_User_UserId",
                table: "UserGjuhet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aftesite_User_UserId",
                table: "Aftesite");

            migrationBuilder.DropForeignKey(
                name: "FK_Edukimi_User_UserId",
                table: "Edukimi");

            migrationBuilder.DropForeignKey(
                name: "FK_Eksperienca_User_UserId",
                table: "Eksperienca");

            migrationBuilder.DropForeignKey(
                name: "FK_HonorsAndAwards_User_UserId",
                table: "HonorsAndAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_Licensat_User_UserId",
                table: "Licensat");

            migrationBuilder.DropForeignKey(
                name: "FK_MbikqyresITemave_User_UserId",
                table: "MbikqyresITemave");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekti_User_UserId",
                table: "Projekti");

            migrationBuilder.DropForeignKey(
                name: "FK_Publikimi_User_UserId",
                table: "Publikimi");

            migrationBuilder.DropForeignKey(
                name: "FK_PunaVullnetare_User_UserId",
                table: "PunaVullnetare");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializimet_User_UserId",
                table: "Specializimet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGjuhet_User_UserId",
                table: "UserGjuhet");

            migrationBuilder.DropIndex(
                name: "IX_UserGjuhet_UserId",
                table: "UserGjuhet");

            migrationBuilder.DropIndex(
                name: "IX_Specializimet_UserId",
                table: "Specializimet");

            migrationBuilder.DropIndex(
                name: "IX_PunaVullnetare_UserId",
                table: "PunaVullnetare");

            migrationBuilder.DropIndex(
                name: "IX_Publikimi_UserId",
                table: "Publikimi");

            migrationBuilder.DropIndex(
                name: "IX_Projekti_UserId",
                table: "Projekti");

            migrationBuilder.DropIndex(
                name: "IX_MbikqyresITemave_UserId",
                table: "MbikqyresITemave");

            migrationBuilder.DropIndex(
                name: "IX_Licensat_UserId",
                table: "Licensat");

            migrationBuilder.DropIndex(
                name: "IX_HonorsAndAwards_UserId",
                table: "HonorsAndAwards");

            migrationBuilder.DropIndex(
                name: "IX_Eksperienca_UserId",
                table: "Eksperienca");

            migrationBuilder.DropIndex(
                name: "IX_Edukimi_UserId",
                table: "Edukimi");

            migrationBuilder.DropIndex(
                name: "IX_Aftesite_UserId",
                table: "Aftesite");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserGjuhet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserGjuhet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Specializimet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Specializimet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PunaVullnetare",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "PunaVullnetare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Publikimi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Publikimi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Projekti",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Projekti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MbikqyresITemave",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "MbikqyresITemave",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Licensat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Licensat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HonorsAndAwards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "HonorsAndAwards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Eksperienca",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Eksperienca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Edukimi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Edukimi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Aftesite",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Aftesite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserGjuhet_UserId1",
                table: "UserGjuhet",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Specializimet_UserId1",
                table: "Specializimet",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PunaVullnetare_UserId1",
                table: "PunaVullnetare",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Publikimi_UserId1",
                table: "Publikimi",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Projekti_UserId1",
                table: "Projekti",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MbikqyresITemave_UserId1",
                table: "MbikqyresITemave",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Licensat_UserId1",
                table: "Licensat",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_HonorsAndAwards_UserId1",
                table: "HonorsAndAwards",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Eksperienca_UserId1",
                table: "Eksperienca",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Edukimi_UserId1",
                table: "Edukimi",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Aftesite_UserId1",
                table: "Aftesite",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Aftesite_User_UserId1",
                table: "Aftesite",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Edukimi_User_UserId1",
                table: "Edukimi",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eksperienca_User_UserId1",
                table: "Eksperienca",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HonorsAndAwards_User_UserId1",
                table: "HonorsAndAwards",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licensat_User_UserId1",
                table: "Licensat",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MbikqyresITemave_User_UserId1",
                table: "MbikqyresITemave",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekti_User_UserId1",
                table: "Projekti",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publikimi_User_UserId1",
                table: "Publikimi",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PunaVullnetare_User_UserId1",
                table: "PunaVullnetare",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializimet_User_UserId1",
                table: "Specializimet",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGjuhet_User_UserId1",
                table: "UserGjuhet",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

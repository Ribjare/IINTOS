using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
    public partial class USerFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "School",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CertificateId",
                table: "AspNetUsers",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserFile_CertificateId",
                table: "AspNetUsers",
                column: "CertificateId",
                principalTable: "UserFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserFile_CertificateId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserFile");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CertificateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "School");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}

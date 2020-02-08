using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
    public partial class professores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolCoordinationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolCoordinationId",
                table: "AspNetUsers",
                column: "SchoolCoordinationId",
                unique: true,
                filter: "[SchoolCoordinationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_School_SchoolCoordinationId",
                table: "AspNetUsers",
                column: "SchoolCoordinationId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_School_SchoolCoordinationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolCoordinationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolCoordinationId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId",
                unique: true,
                filter: "[SchoolId] IS NOT NULL");
        }
    }
}

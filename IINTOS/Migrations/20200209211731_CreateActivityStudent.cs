using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
	public partial class CreateActivityStudent : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
		name: "ActivityStudent",
		columns: table => new
		{
			Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
			ActivityID = table.Column<int>(nullable: false),
			StudentName = table.Column<string>(nullable: false),
			StudentBirth = table.Column<DateTime>(nullable: false)
		},
		constraints: table =>
		{
			table.PrimaryKey("PK_ActivityStudent", x => x.Id);
			table.ForeignKey(
							name: "FK_ActivityStudent_ActivityID",
							column: x => x.ActivityID,
							principalTable: "Activity",
							principalColumn: "Id",
							onDelete: ReferentialAction.Restrict);
		});
		}


		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(name: "ActivityStudent");
		}
	}
}

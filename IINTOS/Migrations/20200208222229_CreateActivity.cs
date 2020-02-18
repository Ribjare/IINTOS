using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
	public partial class CreateActivity : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					name: "Activity",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						Title = table.Column<string>(nullable: false),
						Description = table.Column<string>(nullable: false),
						ProjectID = table.Column<int>(nullable: false),
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Activity", x => x.Id);
						table.ForeignKey(
						 name: "FK_Activity_Activity_ProjectID",
						 column: x => x.ProjectID,
						 principalTable: "Project",
						 principalColumn: "Id",
						 onDelete: ReferentialAction.Restrict);
					});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "Activity");

		}
	}
}

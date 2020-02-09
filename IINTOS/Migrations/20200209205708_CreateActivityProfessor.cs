using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
	public partial class CreateActivityProfessor : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					name: "ActivityProfessor",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						ActivityID = table.Column<int>(nullable: false),
						ProfessorID = table.Column<string>(maxLength: 450, nullable: false),
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ActivityProfessor", x => x.Id);
						table.ForeignKey(
										name: "FK_ActivityProfessor_ActivityID",
										column: x => x.ActivityID,
										principalTable: "Activity",
										principalColumn: "Id",
										onDelete: ReferentialAction.Restrict);
						table.ForeignKey(
										name: "FK_ActivityProfessor_ProfessorID",
										column: x => x.ProfessorID,
										principalTable: "AspNetUsers",
										principalColumn: "Id",
										onDelete: ReferentialAction.Restrict);
					});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(name: "ActivityProfessor");
		}
	}
}

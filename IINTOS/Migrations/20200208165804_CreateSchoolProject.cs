using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
	public partial class CreateSchoolProject : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					 name: "SchoolProject",
					 columns: table => new
					 {
						 Id = table.Column<int>(nullable: false)
									 .Annotation("SqlServer:Identity", "1, 1"),
						 SchoolId = table.Column<int>(nullable: false),
						 ProjectID = table.Column<int>(nullable: false)
					 },
					 constraints: table =>
					 {
						 table.PrimaryKey("PK_SchoolProject", x => x.Id);
						 table.ForeignKey(
                      name: "FK_SchoolProject_School_SchoolId",
                      column: x => x.SchoolId,
                      principalTable: "School",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
              table.ForeignKey(
                      name: "FK_SchoolProject_Project_ProjectId",
                      column: x => x.ProjectID,
                      principalTable: "Project",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
					 });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "SchoolProject");
		}
	}
}

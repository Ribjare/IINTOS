using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
	public partial class CreateProject : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					 name: "Project",
					 columns: table => new
					 {
						 Id = table.Column<int>(nullable: false)
									 .Annotation("SqlServer:Identity", "1, 1"),
						 Goal = table.Column<string>(nullable: false),
						 Description = table.Column<string>(nullable: false),
						 Links = table.Column<string>(nullable: true),
						 TargetAudience = table.Column<string>(nullable: true),
						 Type = table.Column<string>(nullable: false)
					 },
					 constraints: table =>
					 {
						 table.PrimaryKey("PK_Project", x => x.Id);
					 });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "Project");
		}
	}
}

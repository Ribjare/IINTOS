using System;
namespace IINTOS.Models
{
	public class SchoolProject
	{

		public int Id { get; set; }
		public int ProjectId { get; set; }
		public int SchoolId { get; set; }


		public SchoolProject(int ProjectId, int SchoolId)
		{
			this.ProjectId = ProjectId;
			this.SchoolId = SchoolId;
		}
	}
}

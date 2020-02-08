using System;
namespace IINTOS.Models
{
  public class Project
  {

   
    public int Id { get; set; }
    public string Goal { get; set; }
    public string Description { get; set; }
    public string Links { get; set; }
    public string TargetAudience { get; set; }
    public char Type { get; set; }
  }
}

using System;
namespace IINTOS.Models
{
  public class ActivityStudent
  {
    public int Id { get; set; }
    
    public int ActivityID { get; set; }
    public string StudentName { get; set; }
    public DateTime StudentBirth { get; set; }
  }
}

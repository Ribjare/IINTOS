using System;
using System.ComponentModel.DataAnnotations;

namespace IINTOS.Models
{
  
  public class Project
  {

   
    public int Id { get; set; }
    public string Goal { get; set; }
    public string Description { get; set; }
    public string Links { get; set; }

    [Display(Name = "Target Audience")]
    public string TargetAudience { get; set; }
    public string Type { get; set; }
  }
}

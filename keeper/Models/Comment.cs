using System.ComponentModel.DataAnnotations;

namespace keeper.Models 
{
  public class Comment 
  {
    public int Id {get;set;}
    [Required]
    public string Body {get;set;}
    public int KeepId {get;set;}
    public string CreatorId {get;set;}
    public Profile Creator {get;set;}
  }
}
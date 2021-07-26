using System.ComponentModel.DataAnnotations;

namespace keeper.Models
{
  public class Keep
  {
    public int Id {get;set;}
    [Required]
    public string Name {get;set;}
    public string CreatorId {get;set;}
    public string Description {get;set;}
    public string Img {get;set;}
    public int Views {get;set;} = 0;
    public int Shares {get;set;} = 0;
    public int Keeps {get;set;} = 0;
    public Profile Creator {get;set;}
  }
  public class KeepsViewModel: Keep
  {
        public int VaultKeepId {get;set;}
  }
}
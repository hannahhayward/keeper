using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _kr;
    public KeepsService(KeepsRepository kr)
    {
      _kr = kr;
    }
    public Keep Create(Keep keep)
    {
     return _kr.Create(keep);
    }
    public List<Keep> GetAll()
    {
      return _kr.GetAll();
    }
  }
}
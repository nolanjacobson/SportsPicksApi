using System;

namespace SportsPicksApi.Models
{
  public class NewGame
  {
    public int Id { get; set; }
    public string Sport { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public string WinningTeam { get; set; }
    public string Description { get; set; }
    public string PostDate { get; set; }

  }
}
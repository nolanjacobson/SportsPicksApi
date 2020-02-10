using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPicksApi.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public string HashedPassword { get; set; }

    [Required]
    public string Email { get; set; }
    public string FullName { get; set; }

    public bool isPaying { get; set; } = false;
    public string MembershipExpiration { get; set; } = "";

  }
}
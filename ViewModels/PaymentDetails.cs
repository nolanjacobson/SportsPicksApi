using System;

namespace SportsPicksApi.ViewModels
{
  public class PaymentDetails
  {
    public bool isPaying { get; set; }
    public int MembershipLength { get; set; }

    public DateTime MembershipCreated { get; set; }
  }
}
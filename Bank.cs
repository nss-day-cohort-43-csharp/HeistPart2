using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamSixHeist
{
  public class Bank
  {
    public Bank()
    {
      Random r = new Random();
      CashOnHand = r.Next(50_000, 1_000_001);
      AlarmScore = r.Next(0, 101);
      VaultScore = r.Next(0, 101);
      SecurityGuardScore = r.Next(0, 101);

      //check for duplicates
      while (AlarmScore == VaultScore || AlarmScore == SecurityGuardScore || SecurityGuardScore == VaultScore)
      {
        AlarmScore = r.Next(0, 101);
        VaultScore = r.Next(0, 101);
        SecurityGuardScore = r.Next(0, 101);
      }

    }
    public int CashOnHand { get; set; }
    public int AlarmScore { get; set; }
    public int VaultScore { get; set; }
    public int SecurityGuardScore { get; set; }

    public Boolean IsSecure
    {
      get
      {
        if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
        {
          return false;
        }

        return true;
      }
    }

    public void Recon()
    {
      if (AlarmScore > VaultScore && AlarmScore > SecurityGuardScore)
      {
        Console.WriteLine("Most Secure: Alarm");
      }
      else if (VaultScore > AlarmScore && VaultScore > SecurityGuardScore)
      {
        Console.WriteLine("Most Secure: Vault");
      }
      else if (SecurityGuardScore > AlarmScore && SecurityGuardScore > VaultScore)
      {
        Console.WriteLine("Most Secure: Security");
      }

      if (AlarmScore < VaultScore && AlarmScore < SecurityGuardScore)
      {
        Console.WriteLine("Least Secure: Alarm");
      }
      else if (VaultScore < AlarmScore && VaultScore < SecurityGuardScore)
      {
        Console.WriteLine("Least Secure: Vault");
      }
      else if (SecurityGuardScore < AlarmScore && SecurityGuardScore < VaultScore)
      {
        Console.WriteLine("Least Secure: Security");
      }

    }
  }
}
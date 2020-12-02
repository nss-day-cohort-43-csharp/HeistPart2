using System;

namespace TeamSixHeist
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        public Boolean IsSecure { get 
            {
                if( AlarmScore <= 0  && VaultScore <= 0 && SecurityGuardScore <= 0)
                {
                    return false;
                }
                
                return true;
            }
        }
    }
}
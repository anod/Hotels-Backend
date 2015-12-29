using System;

namespace HotelsWizard.Models
{
    public class CancellationPolicy
    {
        public int policy;
        public int period;
        public Penalty penaltyLate;
        public int noShowType;
        public String text;

        public class Penalty
        {
            int type;
            int value;
        }
    }

}
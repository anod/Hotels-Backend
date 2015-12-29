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
            public int Type;
            public int Value;
        }
    }

}
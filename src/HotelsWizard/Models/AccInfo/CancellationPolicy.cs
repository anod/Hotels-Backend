using System;

namespace HotelsWizard.Models.AccInfo
{
    public class CancellationPolicy
    {
        public int Policy;
        public int Period;
        public Penalty PenaltyLate;
        public int NoShowType;
        public String Text;

        public class Penalty
        {
            public int Type;
            public int Value;
        }
    }

}
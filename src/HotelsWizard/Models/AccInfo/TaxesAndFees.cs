using System.Collections.Generic;

namespace HotelsWizard.Models.AccInfo
{
    public class TaxesAndFees
    {
        public string Name;
        public int Type;
        public Dictionary<string, double> TotalValue;
        public bool Prepaid;
        public bool DisplayIncluded;
    }
}
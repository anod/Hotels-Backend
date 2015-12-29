using System.Collections.Generic;

namespace HotelsWizard.Models.AccInfo
{
    public class Rate
    {

        public int RateId;

        public string Name;

        public List<string> Images;

        public List<TaxesAndFees> TaxesAndFees;

        public Payment Payment;

        public List<PaymentMethods> PaymentMethods;

        public int Capacity;

        //        public HashMap<Integer, List<String>> beds;

        public string Description;

        public string RateKey;

        public Tags Tags;

        public Dictionary<string, double> BaseRate;

        public Dictionary<string, double> TotalNetRate;

        public Dictionary<string, double> DisplayPrice;

        public Dictionary<string, double> DisplayBaseRate;

        public CancellationPolicy CancellationPolicy;

    }
}
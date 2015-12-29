using System;
using System.Collections.Generic;
using HotelsWizard.Models.AccInfo;

namespace HotelsWizard.Models
{
    public class Accommodation
    {

        public int id;

        public String name;

        public String email;

        public String phone;

        public int starRating;

        public Location location;

        public Dictionary<string, double> fromPrice;

        public List<string> images;

        public String postpaidCurrency;

        public Details details;

        public Summary summary;

        public List<int> mainFacilities;

        public List<Facility> facilities;

        public List<Rate> rates;
        private bool mUnavailable = false;

        public bool IsUnavailable()
        {
            return mUnavailable;
        }

        public Rate GetFirstRate()
        {
            return this.rates != null && this.rates.Count > 0 ? this.rates[0] : null;
        }

        public Rate GetRateById(int rateId)
        {
            if (this.rates == null || this.rates.Count == 0 || rateId == 0)
            {
                return null;
            }

            foreach (Rate rate in rates)
            {
                if (rate.rateId == rateId)
                {
                    return rate;
                }
            }

            return null;
        }

        public String GetPostpaidCurrency()
        {
            return postpaidCurrency;
        }

        public void MarkUnavailable()
        {
            mUnavailable = true;
        }


        public class Rate
        {

            public int rateId;

            public String name;

            public List<String> images;

            public List<TaxesAndFees> taxesAndFees;

            public Payment payment;

            public List<PaymentMethods> paymentMethods;

            public int capacity;

            //        public HashMap<Integer, List<String>> beds;

            public String description;

            public String rateKey;

            public Tags tags;

            public Dictionary<String, Double> baseRate;

            public Dictionary<String, Double> totalNetRate;

            public Dictionary<String, Double> displayPrice;

            public Dictionary<String, Double> displayBaseRate;

            public CancellationPolicy cancellationPolicy;

            public class Payment
            {
                public Dictionary<String, Double> prepaid;
                public Dictionary<String, Double> postpaid;
            }

            public class PaymentMethods
            {
                public String code;
                public String name;
            }

            public class TaxesAndFees
            {
                public String name;
                public int type;
                public Dictionary<String, Double> totalValue;
                public bool prepaid;
                public bool displayIncluded;
            }

            public class Tags
            {
                public bool breakfastIncluded;
                public bool earlyBird;
                public bool freeCancellation;
                public bool lastMinute;
                public bool nonRefundable;
            }
        }



    }

}
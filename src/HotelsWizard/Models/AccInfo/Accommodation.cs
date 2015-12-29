using System;
using System.Collections.Generic;

namespace HotelsWizard.Models.AccInfo
{
    public class Accommodation
    {

        public int Id;

        public String Name;

        public String Email;

        public String Phone;

        public int StarRating;

        public Location Location;

        public Dictionary<string, double> FromPrice;

        public List<string> Images;

        public String PostpaidCurrency;

        public Details Details;

        public Summary Summary;

        public List<int> MainFacilities;

        public List<Facility> Facilities;

        public List<Rate> Rates;
        private bool Unavailable = false;

        public bool IsUnavailable()
        {
            return Unavailable;
        }

        public Rate GetFirstRate()
        {
            return this.Rates != null && this.Rates.Count > 0 ? this.Rates[0] : null;
        }

        public Rate GetRateById(int rateId)
        {
            if (this.Rates == null || this.Rates.Count == 0 || rateId == 0)
            {
                return null;
            }

            foreach (Rate rate in Rates)
            {
                if (rate.RateId == rateId)
                {
                    return rate;
                }
            }

            return null;
        }

        public void MarkUnavailable()
        {
            Unavailable = true;
        }


    }

}
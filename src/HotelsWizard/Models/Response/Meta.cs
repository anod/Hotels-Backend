using System;
using System.Text;
using System.Collections.Generic;

namespace HotelsWizard.Models.Response
{
    public class Meta
    {

        public int statusCode;

        public int totalNrOverall;

        public int totalNr;

        public int limit;

        public int offset;

        public String clientCurrency;

        public int errorCode;

        public String errorMessage;

        public FilterNumbers filterNrs;

        public Price priceFrom;

        public Price priceTo;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Code] ");
            sb.Append(statusCode);
            if (errorCode > 0)
            {
                sb.Append("[Error] ");
                sb.Append(errorCode);
                sb.Append(" ");
                sb.Append(errorMessage);
            }
            return sb.ToString();
        }

        public class FilterNumbers
        {
            // TODO: format issue public List<Integer> stars;
            public Dictionary<int, int> rating;
            public Dictionary<int, int> accType;
            public Dictionary<int, int> facilities;
        }

        public class Price
        {
            public Dictionary<string, double> totalNetRate;
            public Dictionary<string, double> displayPrice;
        }
    }
}
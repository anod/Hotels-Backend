using System;
using System.Text;
using System.Collections.Generic;

namespace HotelsWizard.Models.Response
{
    public class Meta
    {

        public int StatusCode;

        public int TotalNrOverall;

        public int TotalNr;

        public int Limit;

        public int Offset;

        public String ClientCurrency;

        public int ErrorCode;

        public String ErrorMessage;

        public FilterNumbers FilterNrs;

        public Price PriceFrom;

        public Price PriceTo;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Code] ");
            sb.Append(StatusCode);
            if (ErrorCode > 0)
            {
                sb.Append("[Error] ");
                sb.Append(ErrorCode);
                sb.Append(" ");
                sb.Append(ErrorMessage);
            }
            return sb.ToString();
        }

        public class FilterNumbers
        {
            // TODO: format issue public List<Integer> stars;
            public Dictionary<int, int> Rating;
            public Dictionary<int, int> AccType;
            public Dictionary<int, int> Facilities;
        }

        public class Price
        {
            public Dictionary<string, double> TotalNetRate;
            public Dictionary<string, double> DisplayPrice;
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;

namespace HotelsWizard.Models.Response
{
    public class SearchMeta : Meta
    {

        public int TotalNrOverall;

        public int TotalNr;

        public int Limit;

        public int Offset;

        public String ClientCurrency;

        public FilterNumbers FilterNrs;

        public Price PriceFrom;

        public Price PriceTo;

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
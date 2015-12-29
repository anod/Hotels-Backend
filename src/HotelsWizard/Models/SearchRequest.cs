using System;
using System.Collections.Generic;
using HotelsWizard.Models.Search;

namespace HotelsWizard.Models
{
    /**
     * @author alex
     * @date 2015-05-20
     */
    public class SearchRequest : HotelRequest
    {

        public ContextType Context  { get; set; }
        public string SortType { get; set; }
        
        public Filter Filter { get; set; }

        public SearchRequest() : base()
        {

        }

        public Filter GetFilter()
        {
            if (Filter == null)
            {
                Filter = CreateNewFilter();
            }

            return Filter;
        }

        public bool HaveFilter()
        {
            return Filter != null && !Filter.IsEmpty();
        }

        public void RemoveFilter()
        {
            Filter = null;
        }

        protected Filter CreateNewFilter()
        {
            return new Filter();
        }
    }
}
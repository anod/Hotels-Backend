using System;
using System.Collections.Generic;

namespace HotelsWizard.Models.Search
{
    public class ListType : ContextType
    {

        private List<string> Hotels = null;

        public ListType() : base(LIST)
        {
        }


        public ListType(List<string> hotels) : base(LIST)
        {
            Hotels = hotels;
        }

        public override String GetContext()
        {
            return String.Join(",", Hotels);
        }


    }
}
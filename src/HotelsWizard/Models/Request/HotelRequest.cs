using System;

namespace HotelsWizard.Models.Request
{
    /**
     * @author alex
     * @date 2015-05-26
     */
    public class HotelRequest
    {

        protected DateRange DateRange { get; set; }
        protected int NumbersOfRooms { get; set; }
        protected int NumberOfPersons { get; set; }

        protected String Currency = "EUR";
        protected string Language { get; set; }
        private String CustomerCountryCode { get; set; }


        public HotelRequest()
        {
            NumbersOfRooms = 1;
            NumberOfPersons = 2;
            DateRange = DateRange.getInstance();
        }

    }
}
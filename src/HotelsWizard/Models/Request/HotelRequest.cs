using System;

namespace HotelsWizard.Models.Request
{
    /**
     * @author alex
     * @date 2015-05-26
     */
    public class HotelRequest
    {

        public DateRange DateRange { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfPersons { get; set; }

        public string Currency = "EUR";
        public string Language { get; set; }
        public String CustomerCountryCode { get; set; }


        public HotelRequest()
        {
            NumberOfRooms = 1;
            NumberOfPersons = 2;
            DateRange = DateRange.getInstance();
        }

    }
}
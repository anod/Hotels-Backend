using System.Collections.Generic;

namespace HotelsWizard.Models.AccInfo
{

    public class Details {

        public string GeneralDescription;
        public string ImportantInfo;
        public string Location;
        public string PublicTransportation;
        public string CheckInFrom;
        public string CheckInUntil;
        public string CheckOutFrom;
        public string CheckOutUntil;
        public string CheckInTime;
        public string CheckOutTime;
        public int NrOfRooms;
        public PetsPolicy PetsPolicy;
        public List<PostPaidCreditCard> PostpaidCreditCards;

    }
    
}
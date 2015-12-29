using System.Collections.Generic;

namespace HotelsWizard.Models.AccInfo
{

    public class Details {

        public string generalDescription;
        public string importantInfo;
        public string location;
        public string publicTransportation;
        public string checkInFrom;
        public string checkInUntil;
        public string checkOutFrom;
        public string checkOutUntil;
        public string checkInTime;
        public string checkOutTime;
        public int nrOfRooms;
        public PetsPolicy petsPolicy;
        public List<PostPaidCreditCard> postpaidCreditCards;

        public class PetsPolicy {
            public int petsAllowed;
            public bool petsAllowedOnRequest;
            public string petsSurcharge;

            public PetsPolicy() {
                this.petsAllowed = 0;
                this.petsAllowedOnRequest = false;
                this.petsSurcharge = "";
            }
        }

    }
    
}
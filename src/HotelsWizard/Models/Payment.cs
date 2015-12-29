using System;

namespace HotelsWizard.Models
{
    public class Payment
    {
        public string type;
        public Data data;
        public Address billingAddress;

        public class Data
        {
        }

        public class CreditCardData : Data
        {
            public string ccNr;
            public string ccCvc;
            public string ccFirstName;
            public string ccLastName;
            public int ccExpiryMonth;
            public int ccExpiryYear;
        }

        public class Address
        {
            public string country;
            public string state;
            public string city;
            public string address;
            public string postalCode;
        }
    }
}
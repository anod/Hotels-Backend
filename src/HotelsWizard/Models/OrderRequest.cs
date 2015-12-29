using System;
using System.Collections.Generic;
using HotelsWizard.Models.Search;

namespace HotelsWizard.Models
{
    /**
     * @author alex
     * @date 2015-04-19
     */
    public class OrderRequest
    {

        private string lang { get; set; }
        private string currency { get; set; }
        private string customerIP { get; set; }
        private Personal personal { get; set; }
        private Payment payment { get; set; }
        private List<Rate> rates { get; set; }

        private OrderRequest()
        {
        }

        private class Rate
        {
            public String rateKey { get; set; }
            public int rateCount { get; set; }
            public List<String> beds { get; set; }
            public String remarks { get; set; }
        }

        public class Builder
        {
            private String Lang { get; set; }
            private String Currency { get; set; }
            private String CustomerIP { get; set; }
            private Payment Payment { get; set; }
            private List<Rate> Rates { get; set; }
            private Personal Personal { get; set; }

            public Builder SetCreditCard(String type, String number, String cvc, String firstName, String lastName, int expMonth, int expYear)
            {
                if (Payment == null)
                {
                    Payment = new Payment();
                }
                Payment.type = type;
                Payment.CreditCardData data = new Payment.CreditCardData();
                data.ccNr = number;
                data.ccCvc = cvc;
                data.ccFirstName = firstName;
                data.ccLastName = lastName;
                data.ccExpiryMonth = expMonth;
                data.ccExpiryYear = expYear;
                Payment.data = data;
                return this;
            }

            public Builder SetPayment(String type, Payment.Data data)
            {
                if (Payment == null)
                {
                    Payment = new Payment();
                }
                Payment.type = type;
                Payment.data = data;
                return this;
            }

            public Builder SetBillingAddress(String country, String state, String city, String address, String postalCode)
            {
                if (Payment == null)
                {
                    Payment = new Payment();
                }
                Payment.Address billingAddress = new Payment.Address();

                billingAddress.country = country;
                billingAddress.state = state;
                billingAddress.city = city;
                billingAddress.address = address;
                billingAddress.postalCode = postalCode;

                Payment.billingAddress = billingAddress;
                return this;
            }

            public Builder AddRate(String rateKey, int rateCount, List<String> beds, String remarks)
            {
                if (Rates == null)
                {
                    Rates = new List<Rate>();
                }
                Rate rate = new Rate();
                rate.rateKey = rateKey;
                rate.rateCount = rateCount;
                rate.beds = beds;
                rate.remarks = remarks;
                Rates.Add(rate);
                return this;
            }

            public Builder SetPersonal(String firstName, String lastName, String phone, String country, String email)
            {
                Personal = new Personal();
                Personal.firstName = firstName;
                Personal.lastName = lastName;
                Personal.phone = phone;
                Personal.country = country;
                Personal.email = email;
                return this;
            }


            public OrderRequest Build()
            {
                OrderRequest request = new OrderRequest();
                request.lang = Lang;
                request.currency = Currency;
                request.customerIP = CustomerIP;
                request.payment = Payment;
                request.personal = Personal;
                request.rates = Rates;
                return request;
            }


        }
    }
}
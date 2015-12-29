using System;
using System.Collections.Generic;
using HotelsWizard.Models.OrderInfo;

namespace HotelsWizard.Models.Request
{
    /**
     * @author alex
     * @date 2015-04-19
     */
    public class OrderRequest
    {

        private string Lang { get; set; }
        private string Currency { get; set; }
        private string CustomerIP { get; set; }
        private Personal Personal { get; set; }
        private Payment Payment { get; set; }
        private List<Rate> Rates { get; set; }

        private OrderRequest()
        {
        }

        private class Rate
        {
            public String RateKey { get; set; }
            public int RateCount { get; set; }
            public List<String> Beds { get; set; }
            public String Remarks { get; set; }
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
                rate.RateKey = rateKey;
                rate.RateCount = rateCount;
                rate.Beds = beds;
                rate.Remarks = remarks;
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
                request.Lang = Lang;
                request.Currency = Currency;
                request.CustomerIP = CustomerIP;
                request.Payment = Payment;
                request.Personal = Personal;
                request.Rates = Rates;
                return request;
            }


        }
    }
}
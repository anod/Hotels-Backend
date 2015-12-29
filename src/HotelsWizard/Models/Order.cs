using System;
using System.Collections.Generic;

namespace HotelsWizard.Models
{
/**
 * @author alex
 * @date 2015-04-28
 */
public class Order {
    public int orderId;
    public Personal personal;
    public Payment payment;
    public List<Rate> rates;

    public class Rate {
        public int accommodationId;
        public Accommodation accommodation;
        public int rateId;
        public String statusCode;
        public String confirmationId;
        public String capacity;
        public String password;
        public String name;
        public int rateCount;
        public String checkIn;
        public String checkOut;
        // TODO: public Charge charge
        public Breakfast breakfast;
        public CancellationPolicy cancellationPolicy;
        public String cancellationPolicyText;
        public List<string> beds;
        public String remarks;
        public Charge charge;
        public List<TaxesAndFees> taxesAndFees;

    }
}
}
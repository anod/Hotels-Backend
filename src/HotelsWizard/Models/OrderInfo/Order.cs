using System;
using System.Collections.Generic;
using HotelsWizard.Models.AccInfo;

namespace HotelsWizard.Models.OrderInfo
{
/**
 * @author alex
 * @date 2015-04-28
 */
public class Order {
    public int OrderId;
    public Personal Personal;
    public Payment Payment;
    public List<Rate> Rates;

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
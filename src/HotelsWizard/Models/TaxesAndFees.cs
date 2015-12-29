using System;
using System.Collections.Generic;

namespace HotelsWizard.Models
{
    /**
     * @author alex
     * @date 2015-09-07
     */
    public class TaxesAndFees
    {
        public String name;
        public int type;

        //    public Dictionary<string, double> value; API problem
        public Dictionary<string, double> totalValue;
        public bool prepaid;
    }

}


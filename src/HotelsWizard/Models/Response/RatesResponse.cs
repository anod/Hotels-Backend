using HotelsWizard.Models.AccInfo;
using System.Collections.Generic;

namespace HotelsWizard.Models.Response
{
    /**
     * @author alex
     * @date 2015-04-19
     */
    public class RatesResponse : ApiResponse
    {
        public Meta Meta;

        public List<Rate> Rates;
    }
}
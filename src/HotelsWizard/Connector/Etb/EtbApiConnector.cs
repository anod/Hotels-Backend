using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsWizard.Connector.Etb
{
    public class EtbApiConnector : EtbApi {
        const string APIKEY = "QYU678UxZwFHV";
        const int CAMPAIGN_ID = 280833395;

        public EtbApiConnector() : base(APIKEY, CAMPAIGN_ID) { }
    }
}

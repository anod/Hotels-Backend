
namespace HotelsWizard.Connector.Etb
{
    /**
     * @author alex
     * @date 2015-04-28
     */
    public class EtbApiConfig
    {

        const string ETB_API_ENDPOINT_DEFAULT = "http://api.easytobook.com";
        const string ETB_API_ENDPOINT_SECURE = "https://api.easytobook.com";

        public string ApiKey;
        public string Endpoint = ETB_API_ENDPOINT_DEFAULT;


        public string SecureEndpoint = ETB_API_ENDPOINT_SECURE;

        public bool Debug;
        public int CampaignId;
        //private HttpLoggingInterceptor.Logger logger;

        public EtbApiConfig(string apiKey, int campaignId)
        {
            this.ApiKey = apiKey;
            this.CampaignId = campaignId;
        }

    }

}

using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace HotelsWizard.Controllers
{
    [MobileAppController]
    public class SearchController : ApiController
    {
        // GET api/Look
        public string Get()
        {
            return "Hello from custom controller!";
        }
    }
}

using Microsoft.AspNet.Mvc;

using HotelsWizard.Models.Response;
using HotelsWizard.Connector.Etb;
using HotelsWizard.Connector.Etb.Utils;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelsWizard.Connector;

namespace HotelsWizard.Controllers
{
    [Route("api/[controller]")]
    public class AccommodationsController : JsonController
    {
        private ILogger<AccommodationsController> Logger;

        public AccommodationsController(ILogger<AccommodationsController> logger)
        {
            Logger = logger;
        }
        // GET: api/accommodation
        [HttpGet]
        public async Task<JsonResult> Get()
        {

            var etbapi = new EtbApi("QYU678UxZwFHV", 280833395);
            etbapi.Logger = Logger;

           var query = new QueryCollection(Request.Query);
            try {
                var response = await etbapi.search(query);
                return new JsonResult(response);
            } catch (RestException ex) {
                var error = ex.Error;
                var result = new JsonResult(error);
                result.StatusCode = error.Meta.StatusCode;
                return result;
            }

        }



        // GET api/accommodation/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "accommodation";
        }

    }
}

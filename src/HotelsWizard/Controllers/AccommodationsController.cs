using Microsoft.AspNet.Mvc;

using HotelsWizard.Models.Response;
using HotelsWizard.Connector.Etb;
using HotelsWizard.Connector.Etb.Utils;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
        public async Task<ApiResponse> Get()
        {

            var etbapi = new EtbApi("QYU678UxZwFHV", 280833395);
            etbapi.Logger = Logger;

           var query = new QueryCollection(Request.Query);
            try
            {
                return await etbapi.search(query);
            }
            catch (ResponseException e)
            {
                return e.Error;
            }
            // TODO: handle uncought exceptions, HttpStatusCode.InternalServerError

        }



        // GET api/accommodation/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "accommodation";
        }

    }
}

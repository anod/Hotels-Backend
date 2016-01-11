using Microsoft.AspNet.Mvc;

using HotelsWizard.Models.Response;
using HotelsWizard.Connector.Etb;
using HotelsWizard.Connector.Etb.Utils;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelsWizard.Connector;

namespace HotelsWizard.Controllers {
    [Route("api/[controller]")]
    public class AccommodationsController : JsonController {
        private ILogger<AccommodationsController> Logger;
        private IConnector Connector;
        public AccommodationsController(ILogger<AccommodationsController> logger, IConnector connector) {
            Logger = logger;
            Connector = connector;
            Connector.Logger = Logger;
        }
        // GET: api/accommodation
        [HttpGet]
        public async Task<JsonResult> Get() {            
            var query = new QueryCollection(Request.Query);
            try {
                var response = await Connector.Search(query);
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
        public async Task<JsonResult> Get(int id) {
            var query = new QueryCollection(Request.Query);
            try {
                var response = await Connector.Details(id,query);
                return new JsonResult(response);
            } catch (RestException ex) {
                var error = ex.Error;
                var result = new JsonResult(error);
                result.StatusCode = error.Meta.StatusCode;
                return result;
            }
        }

    }
}

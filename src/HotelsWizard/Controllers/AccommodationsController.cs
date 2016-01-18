using Microsoft.AspNet.Mvc;

using HotelsWizard.Models.Response;
using HotelsWizard.Connector.Etb;
using HotelsWizard.Connector.Etb.Utils;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelsWizard.Connector;
using HotelsWizard.Connector.Rest;

namespace HotelsWizard.Controllers {
    [Route("api/[controller]")]
    public class AccommodationsController : RestController {
        public AccommodationsController(ILogger<AccommodationsController> logger, IConnector connector) : base(logger, connector) { }
        // GET: api/accommodation
        [HttpGet]
        public async Task<JsonResult> Get() {            
            var query = new QueryCollection(Request.Query);
            try {
                var response = await Connector.Search(query);
                return new JsonResult(response);
            } catch (RestException ex) {
                return RestError(ex.Error);
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
                return RestError(ex.Error);
            }
        }

        // GET api/accommodation/5/rates
        [HttpGet("{id}/rates")]
        public async Task<JsonResult> GetRates(int id) {
            var query = new QueryCollection(Request.Query);
            try {
                var response = await Connector.Rates(id, query);
                return new JsonResult(response);
            } catch (RestException ex) {
                return RestError(ex.Error);
            }
        }
    }
}

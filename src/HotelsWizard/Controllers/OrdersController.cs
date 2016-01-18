using Microsoft.AspNet.Mvc;

using HotelsWizard.Connector.Etb.Utils;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelsWizard.Connector;
using HotelsWizard.Connector.Rest;
using System.Net.Http;

namespace HotelsWizard.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : RestController {
        public OrdersController(ILogger<OrdersController> logger, IConnector connector) : base(logger, connector) { }

        // GET api/orders/{id}
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id) {
            var query = new QueryCollection(Request.Query);
            try {
                var response = await Connector.Retrieve(id, null);
                return new JsonResult(response);
            } catch (RestException ex) {
                return RestError(ex.Error);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Create() {
            var request = new StreamContent(Request.Body);
            try {
                var response = await Connector.Order(request);
                return new JsonResult(response);
            } catch (RestException ex) {
                return RestError(ex.Error);
            }
        }

    }
}

using Microsoft.AspNet.Mvc;

using HotelsWizard.Connector.Etb.Utils;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelsWizard.Connector;
using HotelsWizard.Models.Response;

namespace HotelsWizard.Controllers
{
    [Produces("application/json")]
    public abstract class RestController : Controller
    {
        protected ILogger<RestController> Logger;
        protected IConnector Connector;

        protected RestController(ILogger<RestController> logger, IConnector connector) {
            Logger = logger;
            Connector = connector;
            Connector.Logger = Logger;
        }

        protected JsonResult RestError(ErrorResponse error) {
            var result = new JsonResult(error);
            result.StatusCode = error.Meta.StatusCode;
            return result;
        }

    }
}

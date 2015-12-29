using Microsoft.AspNet.Mvc;

using HotelsWizard.Models.Response;
using HotelsWizard.Models.AccInfo;

namespace HotelsWizard.Controllers
{
    [Route("api/[controller]")]
    public class AccommodationsController : JsonController
    {
        // GET: api/accommodation
        [HttpGet]
        public SearchResponse Get()
        {
            SearchResponse response = new SearchResponse();
            response.meta = new Meta();
            response.meta.StatusCode = 200;

            return response;
        }

        // GET api/accommodation/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "accommodation";
        }

    }
}

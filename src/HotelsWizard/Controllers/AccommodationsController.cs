using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using HotelsWizard.Models.Response;

namespace HotelsWizard.Controllers
{
    [Route("api/[controller]")]
    public class AccommodationsController : JsonController
    {
        // GET: api/accommodation
        [HttpGet]
        public Search Get()
        {
            Search response = new Search();
            response.meta = new Meta();

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

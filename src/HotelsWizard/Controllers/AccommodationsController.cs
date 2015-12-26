using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace HotelsWizard.Controllers
{
    [Route("api/[controller]")]
    public class AccommodationsController : Controller
    {
        // GET: api/accommodation
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "accommodation1", "accommodation2" };
        }

        // GET api/accommodation/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "accommodation";
        }

    }
}

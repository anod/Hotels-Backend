using System;
using Microsoft.AspNet.Mvc;


namespace HotelsWizard.Controllers
{
    [Produces("application/json")]
    public abstract class JsonController : Controller
    {
        protected JsonController() {

        }
    }
}

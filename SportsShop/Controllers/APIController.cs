using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckoutSystem.Controllers
{
    [Produces("application/json")]
    public class APIController : Controller
    {
        // GET: api/API
        [HttpGet]
        [Route("API/Ping")]
        public string Get()
        {
            return "pong";
        }
    }
}

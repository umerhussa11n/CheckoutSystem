using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CheckoutSystem.Controllers
{
    /// <summary>
    /// boilerplate, however this 
    /// </summary>
    [Produces("application/json")]
    [Route("api/StandardAPI")]
    public class StandardAPIController : Controller
    {
        // GET: api/StandardAPI
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Return :", "SomeData" };
        }

        // GET: api/StandardAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "Posted value :" + id.ToString();
        }
        
        // POST: api/StandardAPI
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // save the posted data to the database.. 
        }
        
        // PUT: api/StandardAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // similar to Post however this is Idempotent, hence there will be 
            // no effect if same request is made second time..
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // we can used this to delete a record from the database.. 
        }
    }
}

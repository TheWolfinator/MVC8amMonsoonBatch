using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebApi.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Employees()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            return "Post Success";
        }

        // PUT api/values/5
        public string Put(int id, [FromBody]string value)
        {
            return "Put Success";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return "Delete Success";
        }

        [Route("Pizza/burger/{id}")]
        public IEnumerable<string> GetHungry(int id, UserInfoViewModel obj)
        {
            if (id == 1)
            {
                return new string[] { "Veg Pizza", "NonVeg Pizza" };

            }
            else
            {
                return new string[] { "Osmania biscuit", "Cake" };

            }
        }
    }
}

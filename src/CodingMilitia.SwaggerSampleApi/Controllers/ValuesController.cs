using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingMilitia.SwaggerSampleApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Gets all available values.
        /// </summary>
        /// <returns>A collection of values.</returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets a value given its id.
        /// </summary>
        /// <param name="id">The id of the value to fetch.</param>
        /// <returns>The requested value.</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates a new value.
        /// </summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Updates the provided value.
        /// </summary>
        /// <param name="id">The id of the value to update.</param>
        /// <param name="value">The new value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete a value given its id.
        /// </summary>
        /// <param name="id">The id of the value to delete.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

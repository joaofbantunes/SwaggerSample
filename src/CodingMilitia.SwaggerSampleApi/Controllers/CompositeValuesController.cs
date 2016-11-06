using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CodingMilitia.SwaggerSampleApi.Model;

namespace CodingMilitia.SwaggerSampleApi.Controllers
{
    /// <summary>
    /// Provides access to composite values.
    /// </summary>
    [Route("api/[controller]")]
    public class CompositeValuesController : Controller
    {

        private static List<CompositeValue> Values = new List<CompositeValue> { new CompositeValue { Id = 1, Value = "Value1" }, new CompositeValue { Id = 2, Value = "Value2" } };

        /// <summary>
        /// Gets all available composite values.
        /// </summary>
        /// <returns>A collection of composite values.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompositeValue>), 200)]
        public IEnumerable<CompositeValue> Get()
        {
            return Values;
        }

        /// <summary>
        /// Gets a value given its id.
        /// </summary>
        /// <param name="id">The id of the value to fetch.</param>
        /// <returns>The requested value.</returns>
        [HttpGet("{id}", Name = "GetCompositeValue")]
        [ProducesResponseType(typeof(CompositeValue), 200)]
        [ProducesResponseType(typeof(CompositeValue), 404)]
        public ActionResult Get(int id)
        {
            var value = Values.FirstOrDefault(v => v.Id == id);
            return value != null ? Ok(value) as ActionResult : NotFound();
        }

        /// <summary>
        /// Creates a new value.
        /// </summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        [ProducesResponseType(typeof(CompositeValue), 201)]
        [ProducesResponseType(typeof(CompositeValue), 409)]
        public ActionResult Post([FromBody]CompositeValue value)
        {
            if (!Values.Any(v => v.Id == value.Id))
            {
                Values.Add(value);
                return CreatedAtRoute("GetCompositeValue", new { id = value.Id }, value);
            }
            return StatusCode(409);
        }

        /// <summary>
        /// Updates the provided value.
        /// </summary>
        /// <param name="id">The id of the value to update.</param>
        /// <param name="newValue">The new value.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CompositeValue), 200)]
        [ProducesResponseType(typeof(CompositeValue), 404)]
        public ActionResult Put(int id, [FromBody]CompositeValue newValue)
        {
            var value = Values.FirstOrDefault(v => v.Id == id);
            if (value != null)
            {
                value.Value = newValue.Value;
                return Ok(value);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete a value given its id.
        /// </summary>
        /// <param name="id">The id of the value to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CompositeValue), 204)]
        [ProducesResponseType(typeof(CompositeValue), 404)]
        public ActionResult Delete(int id)
        {
            var value = Values.FirstOrDefault(v => v.Id == id);
            if (value != null)
            {
                Values = Values.Where(v => v.Id != id).ToList();
                return NoContent();
            }
            return NotFound();
        }
    }
}

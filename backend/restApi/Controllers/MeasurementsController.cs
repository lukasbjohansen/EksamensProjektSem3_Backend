using Microsoft.AspNetCore.Mvc;
using restApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly MeasurementsRepoList _measurementService;
        public MeasurementsController(MeasurementsRepoList measurementService)
        {
            _measurementService = measurementService;
        }
        // GET: api/<MeasurementsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Measurement>> Get()
        {
            if (_measurementService.Count == 0)
            {
                return NoContent();
            }
            return Ok(_measurementService.GetAllMeasurements());
        }

        // GET api/<MeasurementsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Measurement> Get(int id)
        {
            Measurement? measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return Ok(measurement);
        }

        // POST api/<MeasurementsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeasurementsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeasurementsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

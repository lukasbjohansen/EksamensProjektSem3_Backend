using Microsoft.AspNetCore.Mvc;
using restApi.Data;
using restApi.Dtos;
using restApi.Models;

namespace restApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MeasurementController : ControllerBase
	{
		private readonly AppDbContext _context;

		public MeasurementController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Create(
			CreateMeasurementRequest request)
		{
			var measurement = new Measurement(
				request.Temperature,
				request.Humidity
			);

			_context.Measurements.Add(measurement);

			await _context.SaveChangesAsync();

			return Ok(measurement);
		}
	}
}
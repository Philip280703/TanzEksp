using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin, User")]
	public class TripEventController : ControllerBase
	{
		private readonly TripEventUseCase _tripEventUseCase;

		public TripEventController(TripEventUseCase tripEventUseCase)
		{
			_tripEventUseCase = tripEventUseCase;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var tripEvents = await _tripEventUseCase.GetAll();
			return Ok(tripEvents);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var tripEvent = await _tripEventUseCase.GetByid(id);
			if (tripEvent == null)
			{
				return NotFound();
			}
			return Ok(tripEvent);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] TripEvent tripEvent)
		{
			if (tripEvent == null)
			{
				return BadRequest();
			}
			await _tripEventUseCase.Add(tripEvent);
			return CreatedAtAction(nameof(GetById), new { id = tripEvent.Id }, tripEvent);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] TripEvent tripEvent)
		{
			if (id != tripEvent.Id || tripEvent == null)
			{
				return BadRequest();
			}
			await _tripEventUseCase.Update(tripEvent);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var tripEvent = await _tripEventUseCase.GetByid(id);
			if (tripEvent == null)
			{
				return NotFound();
			}
			await _tripEventUseCase.Delete(id);
			return NoContent();
		}
	}
}

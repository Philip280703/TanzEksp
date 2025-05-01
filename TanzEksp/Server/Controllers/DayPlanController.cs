using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class DayPlanController : ControllerBase
    {
        private readonly DayPlanUseCase _dayplanUsecase;

        public DayPlanController(DayPlanUseCase dayplanUsecase)
        {
            _dayplanUsecase = dayplanUsecase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tripEvents = await _dayplanUsecase.GetAll();
            return Ok(tripEvents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tripEvent = await _dayplanUsecase.GetById(id);
            if (tripEvent == null)
            {
                return NotFound();
            }
            return Ok(tripEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DayPlan dayPlan)
        {
            if (dayPlan == null)
            {
                return BadRequest();
            }
            await _dayplanUsecase.Add(dayPlan);
            return CreatedAtAction(nameof(GetById), new { id = dayPlan.Id }, dayPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DayPlan dayPlan)
        {
            if (id != dayPlan.Id || dayPlan == null)
            {
                return BadRequest();
            }
            await _dayplanUsecase.Update(dayPlan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tripEvent = await _dayplanUsecase.GetById(id);
            if (tripEvent == null)
            {
                return NotFound();
            }
            await _dayplanUsecase.Delete(id);
            return NoContent();
        }

    }
}

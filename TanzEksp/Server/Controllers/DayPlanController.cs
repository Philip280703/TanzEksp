using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{

    [ApiController]
    [Route("/api[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class DayPlanController : ControllerBase
    {
        private readonly DayPlanUseCase _dayplanUsecase;

        public DayPlanController(DayPlanUseCase dayplanUsecase)
        {
            _dayplanUsecase = dayplanUsecase;
        }

        //[HttpGet]
        //public IActionResult

    }
}

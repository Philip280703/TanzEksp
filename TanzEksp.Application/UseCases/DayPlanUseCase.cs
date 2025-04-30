using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.UseCases
{
    public class DayPlanUseCase : IDayPlanRepository
    {
        private readonly IDayPlanRepository _dayPlanrepository;

        public DayPlanUseCase(IDayPlanRepository dayPlanrepository)
        {
            _dayPlanrepository = dayPlanrepository;
        }

        public async Task <List<DayPlan>> GetAll()
        {
            return await _dayPlanrepository.GetAll();
        }

        public async Task<DayPlan> GetById(int id)
        {
            return await _dayPlanrepository.GetById(id);
        }

        public async Task Add(DayPlan dayPlan)
        {
            await _dayPlanrepository.Add(dayPlan);
        }

        public async Task Update(DayPlan dayPlan)
        {
            await _dayPlanrepository.Update(dayPlan);
        }
        public async Task Delete(int id)
        {
            await _dayPlanrepository.Delete(id);
        }
    }
}

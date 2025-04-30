using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.Interfaces
{
    public interface IDayPlanRepository
    {
        Task<List<DayPlan>> GetAll();
        Task<DayPlan> GetById(int id);
        Task Add(DayPlan dayPlan);
        Task Update(DayPlan dayPlan);
        Task Delete(int id);
    }
}

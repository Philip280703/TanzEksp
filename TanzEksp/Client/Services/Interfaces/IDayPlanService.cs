using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
    public interface IDayPlanService
    {
        Task<List<DayPlanDTO>> GetAll();
        Task <DayPlanDTO> GetById(int id);
        Task<int> AddDayPlanAsync(DayPlanDTO dayPlan);
        Task<int> UpdateDayPlanAsync(DayPlanDTO dayPlan);
        Task<int> DeleteDayPlanAsync(int id);
    }
}

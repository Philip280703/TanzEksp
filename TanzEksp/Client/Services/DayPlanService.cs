using System.Net.Http.Json;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
    public class DayPlanService : IDayPlanService
    {
        private readonly HttpClient _httpClient;

        public DayPlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DayPlanDTO>> GetAll()
        {
            var dayPlans = await _httpClient.GetFromJsonAsync<List<DayPlanDTO>>("api/dayplan");
            if (dayPlans == null)
            {
                throw new Exception("Failed to load Dayplans");
            }
            return dayPlans;
        }

        public async Task<DayPlanDTO> GetById(int id)
        {
            var dayPlans = await _httpClient.GetFromJsonAsync<DayPlanDTO>($"api/dayplan/{id}");
            if (dayPlans == null)
            {
                throw new Exception($"Failed to load dayplan with ID {id}");
            }
            return dayPlans;
        }

        public async Task<int> AddDayPlanAsync(DayPlanDTO dayPlan)
        {
            var answer = await _httpClient.PostAsJsonAsync("api/dayplan", dayPlan);
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }

        public async Task<int> UpdateDayPlanAsync(DayPlanDTO dayPlan)
        {
            var answer = await _httpClient.PutAsJsonAsync($"api/dayplan/{dayPlan.Id}", dayPlan);
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }

        public async Task<int> DeleteDayPlanAsync(int id)
        {
            var answer = await _httpClient.DeleteAsync($"api/dayplan/{id}");
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }
    }
}


using TanzEksp.Client.Services.Interfaces;
using System.Net.Http.Json;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly HttpClient _httpClient;

        public UserAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserAccountDto>> GetAllUserAccountsAsync()
        {
            var response = await _httpClient.GetAsync("api/useraccounts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<UserAccountDto>>();
        }

        public async Task<UserAccountDto?> GetUserAccountByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/useraccounts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserAccountDto>();
            }
            return null;
        }

        public async Task<int> AddUserAccountAsync(UserAccountDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/useraccounts", user);
            response.EnsureSuccessStatusCode();
            return (int)response.StatusCode;
        }

        public async Task<int> UpdateUserAccountAsync(UserAccountDto user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/useraccounts/{user.Id}", user);
            response.EnsureSuccessStatusCode();
            return (int)response.StatusCode;
        }

        public async Task<int> DeleteUserAccountAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/useraccounts/{id}");
            response.EnsureSuccessStatusCode();
            return (int)response.StatusCode;
        }
    }
}

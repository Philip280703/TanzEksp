using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TanzEksp.Client.Auth;
using TanzEksp.Shared.Login;

namespace TanzEksp.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        public string Token { get; private set; }

        public UserService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> Login(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", dto);
            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<JwtResponse>();
            Token = result.Token;
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            if (_authStateProvider is CustomAuthStateProvider provider)
                provider.MarkUserAsAuthenticated(dto.Username, Token);

            return true;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var response = await _http.GetAsync("api/users");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Fejl ved hentning af brugere: {response.StatusCode} - {error}");
                return new List<UserDto>();
            }

            return await response.Content.ReadFromJsonAsync<List<UserDto>>();
        }


        public async Task Register(RegisterDto dto)
        {
            await _http.PostAsJsonAsync("api/users", dto);
        }

        public async Task Update(string id, UpdateUserDto dto)
        {
            await _http.PutAsJsonAsync($"api/users/{id}", dto);
        }

        public async Task Delete(string id)
        {
            await _http.DeleteAsync($"api/users/{id}");
        }
    }
}

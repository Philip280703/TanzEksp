using System.Net.Http.Headers;
using System.Net.Http.Json;
using TanzEksp.Shared.Login;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace TanzEksp.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", new LoginRequest
            {
                Email = email,
                Password = password
            });

            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            await _localStorage.SetItemAsync("authToken", result!.Token);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
            ((ApiAuthenticationStateProvider)_authStateProvider).NotifyAuthenticationStateChanged();

            return true;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _http.DefaultRequestHeaders.Authorization = null;
            ((ApiAuthenticationStateProvider)_authStateProvider).NotifyAuthenticationStateChanged();
        }
    }
}

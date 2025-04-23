using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace TanzEksp.Client.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        private string _token;

        public void MarkUserAsAuthenticated(string username, string token)
        {
            _token = token;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrWhiteSpace(_token))
                return Task.FromResult(new AuthenticationState(_anonymous));

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(_token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }
    }
}

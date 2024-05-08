using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;
using System.Security.Claims;

namespace SingleWebApplicationDefaultAuth.Code.Authentication
{
    public class AzureSwaAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _client;

        public AzureSwaAuthenticationStateProvider(IWebAssemblyHostEnvironment environment)
        {
            _client = new HttpClient { BaseAddress = new Uri(environment.BaseAddress) };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {

                var state = await _client.GetFromJsonAsync<AzureSwaUserAuthenticationState>("/.auth/me");

                if (state == null || state.ClientPrincipal == null)
                {
                    return new AuthenticationState(new ClaimsPrincipal());
                }

                var principal = state.ClientPrincipal;
                principal.UserRoles = principal.UserRoles.Except(new string[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase);

                if (!principal.UserRoles.Any())
                {
                    return new AuthenticationState(new ClaimsPrincipal());
                }

                var identity = new ClaimsIdentity(principal.IdentityProvider);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.UserId));
                identity.AddClaim(new Claim(ClaimTypes.Name, principal.UserDetails));
                identity.AddClaims(principal.UserRoles.Select(r => new Claim(ClaimTypes.Role, r)));

                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }
    }
}

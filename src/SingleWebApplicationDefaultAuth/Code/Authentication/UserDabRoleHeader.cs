using Microsoft.AspNetCore.Components.Authorization;

namespace SingleWebApplicationDefaultAuth.Code.Authentication
{
    public class UserDabRoleHeader
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public UserDabRoleHeader(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        public void SetHeader(HttpClient httpClient)
        {
            var authState = _authenticationStateProvider
                .GetAuthenticationStateAsync().GetAwaiter().GetResult();
            var loggedUser = authState.User;
            var role = loggedUser.FindFirst(AuthConst.RoleClaim)?.Value ?? string.Empty;

            httpClient.DefaultRequestHeaders.Add(AuthConst.DataApiBuilderAuthorizationHeader, role);
        }
    }
}

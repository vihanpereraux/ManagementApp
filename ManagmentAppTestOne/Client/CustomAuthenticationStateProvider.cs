using Blazored.LocalStorage;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            /*Current user is not authenticated*/
            var state = new AuthenticationState(new ClaimsPrincipal());

            string username = await _localStorage.GetItemAsStringAsync("username");
            string userRole = await _localStorage.GetItemAsStringAsync("role");

            if (!string.IsNullOrEmpty(username)) 
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, userRole)
                }, "test authentication type");



                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
    
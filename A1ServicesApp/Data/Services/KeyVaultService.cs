using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Services
{
    public static class KeyVaultService
    {
        public static string DbConnectionString { get; set; }

        public static async Task<string> GetToken(string authority, string resource, string scope, IConfiguration config)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(config["KeyVault:ClientId"], config["KeyVault:ClientSecret"]);

            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
            {
                throw new InvalidOperationException("failed to obtain the JWT token");
            }

            return result.AccessToken;
        }
    }
}

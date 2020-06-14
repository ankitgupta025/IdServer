using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IdServerHost.Config
{
    public static class Configurations
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() 
        {
            return new List<IdentityResource>() 
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource 
                {
                   Name = "rc.scope",
                   UserClaims = { "rc.vigita", "rc.bobby"}  
                }
            };
        }
        public static IEnumerable<ApiResource> GetApis() 
        {
            return new List<ApiResource>() { new ApiResource() 
            {
                Name = "ApiOne",
                Scopes = {new Scope("ApiOne") },
            },
            new ApiResource()
            {
                Name = "ApiClient",
                Scopes = {new Scope("ApiClient") },
            }
            };
        }

        public static IEnumerable<Client> GetClients() 
        {
            return new List<Client>() { new Client()
            {  
                ClientId = "client_id",
                ClientSecrets = {new Secret("client_secret".ToSha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {                   
                    "ApiOne" } 
            },
             new Client()
            {
                ClientId = "client_id_mvc",
                ClientSecrets = {new Secret("client_secret_mvc".ToSha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:44321/signin-oidc" },
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedScopes = {
                    "ApiOne","ApiClient", StandardScopes.OpenId,StandardScopes.Profile,"rc.scope" },
                RequireConsent = false
            }
            };
        }
    }
}

using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("/home")]
        public async Task<IActionResult> Index()
        {
            // retirve access tokn
            var serverClient = _httpClientFactory.CreateClient();

            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44323/");
            var token = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client_id",
                ClientSecret = "client_secret",
                Scope = "ApiOne"

            });

            // retreive secret data

            var client = _httpClientFactory.CreateClient();
            client.SetBearerToken(token.AccessToken);
            var response  = await client.GetAsync("https://localhost:5001/secret");  // apione  44380
            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                access_token = token.AccessToken,
                message = content
            }) ;
        }
    }
}

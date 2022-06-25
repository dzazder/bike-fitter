using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Brakes;
using Newtonsoft.Json;
using System.Net.Http;

namespace BikeFitter.Web.Services
{
    public class RequestService
    {
        private IConfiguration _config;

        public RequestService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<HttpResponseMessage> SendRequest(HttpMethod httpMethod, string address) {
            var apiHost = _config["BikeFitterApiHost"];
            var request = new HttpRequestMessage(httpMethod, $"{apiHost}{address}");
            request.Headers.Add("Accept", "application/json");

            HttpClient client = new HttpClient();
            var response = await client.SendAsync(request);
            
            return response;
        }
    }
}

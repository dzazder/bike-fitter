using BikeFitter.Models.Models;
using BikeFitter.Web.Pages.Cassettes;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class CassetteService
    {
        private readonly RequestService _requestService;

        public CassetteService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Cassette>> GetCassettes()
        {
            try
            {
                var response = await _requestService.Get(Routes.Cassettes);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Cassette>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cassette> GetCassette(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.CassettesParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Cassette>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddCassette(Cassette cassette)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Cassettes, cassette);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditCassette(Cassette cassette)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.CassettesParam(cassette.Id), cassette);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteCassette(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.CassettesParam(id));
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}

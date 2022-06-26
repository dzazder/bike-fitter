using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Cranksets;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class CranksetService
    {
        private readonly RequestService _requestService;

        public CranksetService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Crankset>> GetCranksets()
        {
            try
            {
                var response = await _requestService.Get(Routes.Cranksets);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Crankset>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Crankset> GetCrankset(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.CranksetsParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Crankset>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddCrankset(Crankset crankset)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Cranksets, crankset);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditCrankset(Crankset crankset)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.CranksetsParam(crankset.Id), crankset);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteCrankset(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.CranksetsParam(id));
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

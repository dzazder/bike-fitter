using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Rims;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class RimService
    {
        private readonly RequestService _requestService;

        public RimService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Rim>> GetRims()
        {
            try
            {
                var response = await _requestService.Get(Routes.Rims);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Rim>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Rim> GetRim(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.RimsParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Rim>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddRim(Rim rim)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Rims, rim);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditRim(Rim rim)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.RimsParam(rim.Id), rim);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteRim(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.RimsParam(id));
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

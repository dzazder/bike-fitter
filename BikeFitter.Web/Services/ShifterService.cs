using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Shifters;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class ShifterService
    {
        private readonly RequestService _requestService;

        public ShifterService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Shifter>> GetShifters()
        {
            try
            {
                var response = await _requestService.Get(Routes.Shifters);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Shifter>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Shifter> GetShifter(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.ShiftersParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Shifter>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddShifter(Shifter shifter)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Shifters, shifter);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditShifter(Shifter shifter)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.ShiftersParam(shifter.Id), shifter);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteShifter(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.ShiftersParam(id));
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

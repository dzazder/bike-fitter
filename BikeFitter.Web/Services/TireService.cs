using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Tires;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class TireService
    {
        private readonly RequestService _requestService;

        public TireService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Tire>> GetTires()
        {
            try
            {
                var response = await _requestService.Get(Routes.Tires);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Tire>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tire> GetTire(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.TiresParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tire>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddTire(Tire tire)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Tires, tire);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditTire(Tire tire)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.TiresParam(tire.Id), tire);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteTire(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.TiresParam(id));
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

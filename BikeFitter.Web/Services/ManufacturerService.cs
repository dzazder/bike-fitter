using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Manufacturers;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class ManufacturerService
    {
        private readonly RequestService _requestService;

        public ManufacturerService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            try
            {
                var response = await _requestService.Get(Routes.Manufacturers);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Manufacturer>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Manufacturer> GetManufacturer(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.ManufacturersParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Manufacturer>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddManufacturer(Manufacturer manufacturer)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Manufacturers, manufacturer);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditManufacturer(Manufacturer manufacturer)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.ManufacturersParam(manufacturer.Id), manufacturer);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteManufacturer(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.ManufacturersParam(id));
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

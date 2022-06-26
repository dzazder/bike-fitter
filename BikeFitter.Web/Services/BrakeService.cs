using BikeFitter.Models.Models;
using BikeFitter.Web.Pages.Brakes;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class BrakeService
    {
        private readonly RequestService _requestService;

        public BrakeService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Brake>> GetBrakes()
        {
            try
            {
                var response = await _requestService.Get(Routes.Brakes);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Brake>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Brake> GetBrake(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.BrakesParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Brake>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddBrake(Brake brake)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Brakes, brake);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditBrake(Brake brake)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.BrakesParam(brake.Id), brake);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteBrake(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.BrakesParam(id));
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

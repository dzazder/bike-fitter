using BikeFitter.Api.ApiModel;
using BikeFitter.Api.Models;
using BikeFitter.Web.Routing;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class BikeService
    {
        private readonly RequestService _requestService;

        public BikeService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Bike>> GetBikes()
        {
            try
            {
                var response = await _requestService.Get(Routes.Bikes);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Bike>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Bike> GetBike(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.BikesParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Bike>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddBike(ApiBike bike)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Bikes, bike);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditBike(ApiBike bike)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.BikesParam(bike.Id), bike);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteBike(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.BikesParam(id));
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

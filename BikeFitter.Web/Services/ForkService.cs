using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Forks;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class ForkService
    {
        private readonly RequestService _requestService;

        public ForkService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Fork>> GetForks()
        {
            try
            {
                var response = await _requestService.Get(Routes.Forks);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Fork>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Fork> GetFork(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.ForksParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Fork>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddFork(Fork fork)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Forks, fork);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditFork(Fork fork)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.ForksParam(fork.Id), fork);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteFork(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.ForksParam(id));
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

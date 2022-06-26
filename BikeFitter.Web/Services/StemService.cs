using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Stems;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class StemService
    {
        private readonly RequestService _requestService;

        public StemService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Stem>> GetStems()
        {
            try
            {
                var response = await _requestService.Get(Routes.Stems);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Stem>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Stem> GetStem(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.StemsParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Stem>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddStem(Stem stem)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Stems, stem);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditStem(Stem stem)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.StemsParam(stem.Id), stem);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteStem(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.StemsParam(id));
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

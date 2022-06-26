using BikeFitter.Api.Models;
using BikeFitter.Web.Pages.Derailleurs;
using BikeFitter.Web.Routing;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace BikeFitter.Web.Services
{
    public class DerailleurService
    {
        private readonly RequestService _requestService;

        public DerailleurService(RequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<Derailleur>> GetDerailleurs()
        {
            try
            {
                var response = await _requestService.Get(Routes.Derailleurs);
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Derailleur>>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Derailleur> GetDerailleur(int id)
        {
            try
            {
                var response = await _requestService.Get(Routes.DerailleursParam(id));
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Derailleur>(s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddDerailleur(Derailleur derailleur)
        {
            try
            {
                var response = await _requestService.PostJson(Routes.Derailleurs, derailleur);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> EditDerailleur(Derailleur derailleur)
        {
            try
            {
                var response = await _requestService.PutJson(Routes.DerailleursParam(derailleur.Id), derailleur);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteDerailleur(int id)
        {
            try
            {
                var response = await _requestService.Delete(Routes.DerailleursParam(id));
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

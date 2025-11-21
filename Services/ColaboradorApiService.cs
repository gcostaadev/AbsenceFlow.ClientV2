using AbsenceFlow.ClientV2.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbsenceFlow.ClientV2.Services
{
    public class ColaboradorApiService : IColaboradorApiService
    {
        private readonly HttpClient _httpClient;


        private const string BaseRoute = "api/colaboradores";


        public ColaboradorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ColaboradorViewModel>> GetAllColaboradoresAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<List<ColaboradorViewModel>>(BaseRoute);
            return response ?? new List<ColaboradorViewModel>();
        }

        public async Task<ColaboradorViewModel> GetColaboradorByIdAsync(int id)
        {

            var response = await _httpClient.GetAsync($"{BaseRoute}/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ColaboradorViewModel>();
        }

        public async Task<int> CreateColaboradorAsync(ColaboradorInputModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseRoute, model);


            response.EnsureSuccessStatusCode();


            var createdObject = await response.Content.ReadFromJsonAsync<ColaboradorViewModel>();
            return createdObject.Id;
        }

        public async Task UpdateColaboradorAsync(int id, ColaboradorUpdateModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseRoute}/{id}", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteColaboradorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseRoute}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

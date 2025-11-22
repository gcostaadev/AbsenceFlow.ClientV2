using AbsenceFlow.ClientV2.Enums;
using AbsenceFlow.ClientV2.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AbsenceFlow.ClientV2.Services
{
    public class SolicitacaoApiService : ISolicitacaoApiService
    {
        private readonly HttpClient _httpClient;

        
        private const string BaseRoute = "api/solicitacoes";

        
        public SolicitacaoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<List<SolicitacaoViewModel>> GetAllSolicitacoesAsync()
        {
            
            var solicitacoes = await _httpClient.GetFromJsonAsync<List<SolicitacaoViewModel>>(BaseRoute);

            
            return solicitacoes ?? new List<SolicitacaoViewModel>();
        }

        
        public async Task<SolicitacaoViewModel> GetSolicitacaoByIdAsync(int id)
        {
            
            return await _httpClient.GetFromJsonAsync<SolicitacaoViewModel>($"{BaseRoute}/{id}");
        }

        
        public async Task<int> CreateSolicitacaoAsync(SolicitacaoInputModel model)
        {
            
            var response = await _httpClient.PostAsJsonAsync(BaseRoute, model);

            
            response.EnsureSuccessStatusCode();

            
            var createdObject = await response.Content.ReadFromJsonAsync<SolicitacaoViewModel>();
            return createdObject?.Id ?? throw new System.Exception("API não retornou o ID da solicitação criada.");
        }

        
        public async Task UpdateStatusAsync(int id, SolicitacaoStatusEnum novoStatus)
        {
            
            var updateModel = new StatusUpdateModel
            {
                NovoStatus = novoStatus
            };

            
            var response = await _httpClient.PutAsJsonAsync($"{BaseRoute}/{id}/status", updateModel);

            response.EnsureSuccessStatusCode();
        }

        
        public async Task DeleteSolicitacaoAsync(int id)
        {
            
            var response = await _httpClient.DeleteAsync($"{BaseRoute}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

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

        // Rota base padronizada
        private const string BaseRoute = "api/solicitacoes";

        // O HttpClient é injetado automaticamente pelo Blazor
        public SolicitacaoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Endpoint: GET /api/solicitacoes
        public async Task<List<SolicitacaoViewModel>> GetAllSolicitacoesAsync()
        {
            // CORREÇÃO: Usando a rota padronizada
            var solicitacoes = await _httpClient.GetFromJsonAsync<List<SolicitacaoViewModel>>(BaseRoute);

            // Retorna a lista, ou uma lista vazia se for nula.
            return solicitacoes ?? new List<SolicitacaoViewModel>();
        }

        // Endpoint: GET /api/solicitacoes/{id}
        public async Task<SolicitacaoViewModel> GetSolicitacaoByIdAsync(int id)
        {
            // Usando a rota padronizada
            return await _httpClient.GetFromJsonAsync<SolicitacaoViewModel>($"{BaseRoute}/{id}");
        }

        // Endpoint: POST /api/solicitacoes
        public async Task<int> CreateSolicitacaoAsync(SolicitacaoInputModel model)
        {
            // Usando a rota padronizada
            var response = await _httpClient.PostAsJsonAsync(BaseRoute, model);

            // Lança uma exceção se a requisição não for bem-sucedida (status code 2xx)
            response.EnsureSuccessStatusCode();

            // Tenta ler o ID da nova solicitação criado no corpo da resposta
            // Vamos assumir que o retorno é um objeto com a propriedade Id. Se for apenas um 'int' puro, a linha abaixo precisa de um ajuste.
            // Para maior robustez e consistência com o ColaboradorApiService, vou tentar ler um ViewModel e extrair o ID.
            var createdObject = await response.Content.ReadFromJsonAsync<SolicitacaoViewModel>();
            return createdObject?.Id ?? throw new System.Exception("API não retornou o ID da solicitação criada.");
        }

        // Endpoint: PUT /api/solicitacoes/{id}/status
        public async Task UpdateStatusAsync(int id, SolicitacaoStatusEnum novoStatus)
        {
            // Cria o DTO StatusUpdateModel para enviar no corpo da requisição PUT.
            var updateModel = new StatusUpdateModel
            {
                NovoStatus = novoStatus
            };

            // Envia a requisição PUT para atualizar o status. 
            // Usando a rota padronizada
            var response = await _httpClient.PutAsJsonAsync($"{BaseRoute}/{id}/status", updateModel);

            response.EnsureSuccessStatusCode();
        }

        // Endpoint: DELETE /api/solicitacoes/{id}
        public async Task DeleteSolicitacaoAsync(int id)
        {
            // Usando a rota padronizada
            var response = await _httpClient.DeleteAsync($"{BaseRoute}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

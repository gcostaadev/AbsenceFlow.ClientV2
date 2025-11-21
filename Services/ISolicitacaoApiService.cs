using AbsenceFlow.ClientV2.Models;
using AbsenceFlow.ClientV2.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbsenceFlow.ClientV2.Services
{
    public interface ISolicitacaoApiService
    {
        // CRUD Básico
        Task<List<SolicitacaoViewModel>> GetAllSolicitacoesAsync();
        Task<SolicitacaoViewModel> GetSolicitacaoByIdAsync(int id);
        Task<int> CreateSolicitacaoAsync(SolicitacaoInputModel model);

        // Lógica de Negócio: Atualização de Status (Aprovação/Rejeição)
        Task UpdateStatusAsync(int id, SolicitacaoStatusEnum novoStatus);

        // Soft Delete (Cancelamento)
        Task DeleteSolicitacaoAsync(int id);
    }
}

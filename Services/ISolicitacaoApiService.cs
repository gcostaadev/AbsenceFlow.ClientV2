using AbsenceFlow.ClientV2.Models;
using AbsenceFlow.ClientV2.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbsenceFlow.ClientV2.Services
{
    public interface ISolicitacaoApiService
    {
        
        Task<List<SolicitacaoViewModel>> GetAllSolicitacoesAsync();
        Task<SolicitacaoViewModel> GetSolicitacaoByIdAsync(int id);
        Task<int> CreateSolicitacaoAsync(SolicitacaoInputModel model);

        
        Task UpdateStatusAsync(int id, SolicitacaoStatusEnum novoStatus);

        
        Task DeleteSolicitacaoAsync(int id);
    }
}

using AbsenceFlow.ClientV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AbsenceFlow.ClientV2.Services
{
    public interface IColaboradorApiService
    {
        Task<List<ColaboradorViewModel>> GetAllColaboradoresAsync();
        Task<ColaboradorViewModel> GetColaboradorByIdAsync(int id);
        Task<int> CreateColaboradorAsync(ColaboradorInputModel model);
        Task UpdateColaboradorAsync(int id, ColaboradorUpdateModel model);
        Task DeleteColaboradorAsync(int id);
    }
}

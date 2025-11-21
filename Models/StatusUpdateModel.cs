using AbsenceFlow.ClientV2.Enums;
using System.ComponentModel.DataAnnotations;

namespace AbsenceFlow.ClientV2.Models
{
    public class StatusUpdateModel
    {
        [Required(ErrorMessage = "O novo status da solicitação é obrigatório.")]

        public SolicitacaoStatusEnum NovoStatus { get; set; }
    }
}

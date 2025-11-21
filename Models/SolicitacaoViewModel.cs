using AbsenceFlow.ClientV2.Enums;

namespace AbsenceFlow.ClientV2.Models
{
    public class SolicitacaoViewModel
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public SolicitacaoTipoEnum Tipo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int DiasUteisSolicitados { get; set; } // O resultado da sua lógica inteligente
        public string Motivo { get; set; }
        public SolicitacaoStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }

       



        public SolicitacaoViewModel(int id, int idColaborador, SolicitacaoTipoEnum tipo, DateTime dataInicio, DateTime dataFim, int diasUteisSolicitados, string motivo, SolicitacaoStatusEnum status)
        {
            Id = id;
            IdColaborador = idColaborador;
            Tipo = tipo;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DiasUteisSolicitados = diasUteisSolicitados;
            Motivo = motivo;
            Status = status;

        }
    }
}

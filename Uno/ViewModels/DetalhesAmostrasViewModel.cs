using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class DetalhesAmostrasViewModel : Screen
    {
        public int IdSolicitante { get; set; }
        public int NumSA { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataIdentificacao { get; set; }
        public DateTime Validade { get; set; }
        public string NotaFiscal { get; set; }
        public string Lote { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public DetalhesAmostrasViewModel(int idSolicitante, int numSA, DateTime dataRecebimento, DateTime dataIdentificacao, DateTime validade, string notaFiscal, string lote, string tipo, string descricao)
        {
            IdSolicitante = idSolicitante;
            NumSA = numSA;
            DataRecebimento = dataRecebimento;
            DataIdentificacao = dataIdentificacao;
            Validade = validade;
            NotaFiscal = notaFiscal;
            Lote = lote;
            Tipo = tipo;
            Descricao = descricao;
        }

        public void Fechar()
        {
            TryCloseAsync();
        }
    }
}

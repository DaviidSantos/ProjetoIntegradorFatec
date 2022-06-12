using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class DetalhesAnalisesViewModel : Screen
    {
        public int NumSA { get; set; }
        public int IdSolicitante { get; set; }
        public string TipoDeEstudo { get; set; }
        public string Desintegracao { get; set; }
        public string Dissolucao { get; set; }
        public string PH { get; set; } 
        public string Dureza { get; set; }
        public string Friabilidade { get; set; }
        public string Umidade { get; set; }
        public string Viscosidade { get; set; }
        public string Solubilidade { get; set; }
        public string TeorDoAtivo { get; set; }
        public string TeorDeImpurezas { get; set; }
        public string ParticulasVisiveis { get; set; }
        public string PesoMedio { get; set; }
        public string KarlFischer { get; set; }

        public DetalhesAnalisesViewModel(int numSA, int idSolicitante, string tipoDeEstudo, string desintegracao, string dissolucao, string pH, string dureza, string friabilidade, string umidade, string viscosidade, string solubilidade, string teorDoAtivo, string teorDeImpurezas, string particulasVisiveis, string pesoMedio, string karlFischer)
        {
            NumSA = numSA;
            IdSolicitante = idSolicitante;
            TipoDeEstudo = tipoDeEstudo;
            Desintegracao = desintegracao;
            Dissolucao = dissolucao;
            PH = pH;
            Dureza = dureza;
            Friabilidade = friabilidade;
            Umidade = umidade;
            Viscosidade = viscosidade;
            Solubilidade = solubilidade;
            TeorDoAtivo = teorDoAtivo;
            TeorDeImpurezas = teorDeImpurezas;
            ParticulasVisiveis = particulasVisiveis;
            PesoMedio = pesoMedio;
            KarlFischer = karlFischer;
        }

        public void Fechar()
        {
            TryCloseAsync();
        }
    }
}

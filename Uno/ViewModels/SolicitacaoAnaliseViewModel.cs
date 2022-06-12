using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class SolicitacaoAnaliseViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        public BindableCollection<string> Strings
        {
            get
            {
                return new BindableCollection<string>(
                                 new string[] { "Estudos Desenvolvimento De Metodologia Analítica", "Estudos Validação De Metodologia Analítica", "Estudos Controle De Qualidade", "Estudos De Estabilidade", "Estudos Degradação Forçada", "Estudos Perfil De Dissolução", "Estudos Solubilidade" });
            }
        }

        private int? _idSolicitante;

        public int? IdSolicitante
        {
            get { return _idSolicitante; }
            set
            {
                _idSolicitante = value;
                NotifyOfPropertyChange(() => IdSolicitante);
            }
        }

        private string? _selectedString;

        public string? SelectedString
        {
            get { return _selectedString; }
            set { 
                _selectedString = value;
                NotifyOfPropertyChange(() => SelectedString);
            }
        }

        private string? _desintegracao;

        public string? Desintegracao
        {
            get { return _desintegracao; }
            set
            { 
                _desintegracao = value;
                NotifyOfPropertyChange(() => Desintegracao);
            }
        }

        private string? _dissolucao;

        public string? Dissolucao
        {
            get { return _dissolucao; }
            set {
                _dissolucao = value;
                NotifyOfPropertyChange(() => Dissolucao);
            }
        }

        private string? _friabilidade;

        public string? Friabilidade
        {
            get { return _friabilidade; }
            set
            { 
                _friabilidade = value;
                NotifyOfPropertyChange(() => Friabilidade);
            }
        }

        private string? _umidade;

        public string? Umidade
        {
            get { return _umidade; }
            set {
                _umidade = value;
                NotifyOfPropertyChange(() => Umidade);
            }
        }

        private string? _pH;

        public string? PH
        {
            get { return _pH; }
            set { 
                _pH = value;
                NotifyOfPropertyChange(() => PH);
            }
        }

        private string? _dureza;

        public string? Dureza
        {
            get { return _dureza; }
            set 
            {
                _dureza = value;
                NotifyOfPropertyChange(() => Dureza);
            }
        }

        private string? _viscosidade;

        public string? Viscosidade
        {
            get { return _viscosidade; }
            set {
                _viscosidade = value;
                NotifyOfPropertyChange(() => Viscosidade);
            }
        }

        private string? _solubilidade;

        public string? Solubilidade
        {
            get { return _solubilidade; }
            set { 
                _solubilidade = value;
                NotifyOfPropertyChange(() => Solubilidade);
            }
        }

        private string? _teorAtivo;

        public string? TeorAtivo
        {
            get { return _teorAtivo; }
            set
            { 
                _teorAtivo = value;
                NotifyOfPropertyChange(() => TeorAtivo);
            }
        }

        private string? _teorImpurezas;

        public string? TeorImpurezas
        {
            get { return _teorImpurezas; }
            set 
            { 
                _teorImpurezas = value;
                NotifyOfPropertyChange(() => TeorImpurezas);
            }  
        }

        private string? _karlFischer;

        public string? KarlFischer
        {
            get { return _karlFischer; }
            set
            {
                _karlFischer = value;
                NotifyOfPropertyChange(() => KarlFischer);
            }
        }

        private string? _pesoMedio;

        public string? PesoMedio
        {
            get { return _pesoMedio; }
            set 
            {
                _pesoMedio = value;
                NotifyOfPropertyChange(() => PesoMedio);
            }
        }

        private string? _particulasVisiveis;

        public string? ParticulasVisiveis
        {
            get { return _particulasVisiveis; }
            set 
            {
                _particulasVisiveis = value;
                NotifyOfPropertyChange(() => ParticulasVisiveis);
            }
        }

        public void Cadastrar()
        {
            try
            {
                SqlCommand command =
              new SqlCommand(
                  "INSERT INTO SolicitacaoAnalise(idSolicitante, tipoDeEstudo, desintegracao, dissolucao, pH, dureza, friabilidade, umidade, viscosidade, solubilidade, teorDoAtivo, teorImpurezas, particulasVisiveis, pesoMedio, karlFischer) VALUES(@IdSolicitante, @TipoDeEstudo, @Desintegracao, @Dissolucao, @PH, @Dureza, @Friabilidade, @Umidade, @Viscosidade, @Solubilidade, @TeorDoAtivo, @TeorImpurezas, @ParticulasVisiveis, @PesoMedio, @KarlFischer)", conexaoDB);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@IdSolicitante", _idSolicitante);
                command.Parameters.AddWithValue("@TipoDeEstudo", _selectedString);
                command.Parameters.AddWithValue("@Desintegracao", _desintegracao);
                command.Parameters.AddWithValue("@Dissolucao", _dissolucao);
                command.Parameters.AddWithValue("@PH", _pH);
                command.Parameters.AddWithValue("@Dureza", _dureza);
                command.Parameters.AddWithValue("@Friabilidade", _friabilidade);
                command.Parameters.AddWithValue("@Umidade", _umidade);
                command.Parameters.AddWithValue("@Viscosidade", _viscosidade);
                command.Parameters.AddWithValue("@Solubilidade", _solubilidade);
                command.Parameters.AddWithValue("@TeorDoAtivo", _teorAtivo);
                command.Parameters.AddWithValue("@TeorImpurezas", _teorImpurezas);
                command.Parameters.AddWithValue("@ParticulasVisiveis", _particulasVisiveis);
                command.Parameters.AddWithValue("@PesoMedio", _pesoMedio);
                command.Parameters.AddWithValue("@KarlFischer", _karlFischer);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Solicitação de Análise feita com sucesso");

                IdSolicitante = null;
                SelectedString = null;
                Desintegracao = null;
                Dissolucao = null;
                PH = null;
                Dureza = null;
                Friabilidade = null;
                Umidade = null;
                Viscosidade = null;
                Solubilidade = null;
                TeorAtivo = null;
                TeorImpurezas = null;
                ParticulasVisiveis = null;
                PesoMedio = null;
                KarlFischer = null;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                conexaoDB.Close();
            }
        }

        public void Cancelar()
        {
            IdSolicitante = null;
            SelectedString = null;
            Desintegracao = null;
            Dissolucao = null;
            PH = null;
            Dureza = null;
            Friabilidade = null;
            Umidade = null;
            Viscosidade = null;
            Solubilidade = null;
            TeorAtivo = null;
            TeorImpurezas = null;
            ParticulasVisiveis = null;
            PesoMedio = null;
        }
    }
}

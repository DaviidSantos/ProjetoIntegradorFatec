using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Uno.Views;

namespace Uno.ViewModels
{
    public class AnalisesViewModel : Screen
    {
        private readonly IWindowManager _detalhes = new WindowManager();
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        protected override void OnViewLoaded(object view)
        {
            CarregarDados();
        }

        public void CarregarDados()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM SolicitacaoAnalise", conexaoDB);
            DataTable dt = new DataTable();
            conexaoDB.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dt.Load(sqlDataReader);
            conexaoDB.Close();
            var view = this.GetView() as AnalisesView;
            view.AnalisesDG.ItemsSource = dt.DefaultView;
        }

        public void Excluir()
        {
            var view = this.GetView() as AnalisesView;

            if (view.AnalisesDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    conexaoDB.Open();
                    DataRowView? linha = view.AnalisesDG.SelectedItem as DataRowView;
                    SqlCommand command = conexaoDB.CreateCommand();
                    command.CommandType = CommandType.Text;
                    var id = linha[0];
                    command.CommandText = "DELETE FROM SolicitacaoAnalise WHERE numSA = '" + id + "'";
                    command.ExecuteNonQuery();
                    this.CarregarDados();
                    MessageBox.Show("Solicitação de análise deletada com sucesso!");
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
            else
            {
                MessageBox.Show("Selecione uma solicitação de Análise para excluir");
            }
        }

        public void Detalhes()
        {
            var view = this.GetView() as AnalisesView;

            if (view.AnalisesDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    DataRowView linha = view.AnalisesDG.SelectedItem as DataRowView;
                    int numSA = Convert.ToInt16(linha[0]);
                    int idSolicitante = Convert.ToInt16(linha[1]);
                    string tipoDeEstudo = linha[2].ToString();
                    string desintegracao = linha[3].ToString();
                    string dissolucao = linha[4].ToString();
                    string pH = linha[5].ToString();
                    string dureza = linha[6].ToString();
                    string friabilidade = linha[7].ToString();
                    string umidade = linha[8].ToString();
                    string viscosidade = linha[9].ToString();
                    string solubilidade = linha[10].ToString();
                    string teorDoAtivo = linha[11].ToString();
                    string teorDeImpurezas = linha[12].ToString();
                    string particulasVisiveis = linha[13].ToString();
                    string pesoMedio = linha[14].ToString();
                    string karlFischer = linha[15].ToString();

                    var detalhes = new DetalhesAnalisesViewModel(numSA, idSolicitante, tipoDeEstudo, desintegracao, dissolucao, pH, dureza, friabilidade, umidade, viscosidade, solubilidade, teorDoAtivo, teorDeImpurezas, particulasVisiveis, pesoMedio, karlFischer);
                    _detalhes.ShowWindowAsync(detalhes);



                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.ToString());
                }
            }
            else
            {
                MessageBox.Show("Erro ao selecionar análise");
            }
        }
    }
}

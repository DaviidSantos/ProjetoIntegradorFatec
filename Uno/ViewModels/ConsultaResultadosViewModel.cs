using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using Uno.Views;

namespace Uno.ViewModels
{
    public class ConsultaResultadosViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        private readonly IWindowManager _detalhes = new WindowManager();

        protected override void OnViewLoaded(object view)
        {
            CarregarDados();
        }

        public void CarregarDados()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Resultados", conexaoDB);
            DataTable dt = new DataTable();
            conexaoDB.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dt.Load(sqlDataReader);
            conexaoDB.Close();
            var view = this.GetView() as ConsultaResultadosView;
            view.ResultadosDG.ItemsSource = dt.DefaultView;
        }

        public void Detalhes()
        {
            var view = this.GetView() as ConsultaResultadosView;

            if (view.ResultadosDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    DataRowView linha = view.ResultadosDG.SelectedItem as DataRowView;
                    int numSA = Convert.ToInt16(linha[0]);
                    string tipoDeEstudo = linha[1].ToString();
                    string desintegracao = linha[2].ToString();
                    string dissolucao = linha[3].ToString();
                    string pH = linha[4].ToString();
                    string dureza = linha[5].ToString();
                    string friabilidade = linha[6].ToString();
                    string umidade = linha[7].ToString();
                    string viscosidade = linha[8].ToString();
                    string solubilidade = linha[9].ToString();
                    string teorDoAtivo = linha[10].ToString();
                    string teorDeImpurezas = linha[11].ToString();
                    string particulasVisiveis = linha[12].ToString();
                    string pesoMedio = linha[13].ToString();
                    string karlFischer = linha[14].ToString();

                    var detalhes = new DetalheResultadoViewModel(numSA, tipoDeEstudo, desintegracao, dissolucao, pH, dureza, friabilidade, umidade, viscosidade, solubilidade, teorDoAtivo, teorDeImpurezas, particulasVisiveis, pesoMedio, karlFischer);
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

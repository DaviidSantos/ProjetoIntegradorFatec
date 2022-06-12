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
    public class AmostrasViewModel : Screen
    {
        private readonly IWindowManager _detalhes = new WindowManager();
        private readonly IWindowManager _baixa = new WindowManager();
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        protected override void OnViewLoaded(object view)
        {
            CarregarDados();
        }

        public void CarregarDados()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM RecebimentoAmostras", conexaoDB);
            DataTable dt = new DataTable();
            conexaoDB.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dt.Load(sqlDataReader);
            conexaoDB.Close();
            var view = this.GetView() as AmostrasView;
            view.AmostrasDG.ItemsSource = dt.DefaultView;
        }

        public void Baixa()
        {
            var modal = new BaixaViewModel(this);
            _baixa.ShowDialogAsync(modal);
        }

        public void Detalhes()
        {
            var view = this.GetView() as AmostrasView;

            if (view.AmostrasDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    DataRowView linha = view.AmostrasDG.SelectedItem as DataRowView;
                    int idAmostra = Convert.ToInt16(linha[1]);
                    int idSolicitante = Convert.ToInt16(linha[2]);
                    DateTime dataRecebimento = Convert.ToDateTime(linha[3]);
                    DateTime dataIdentificacao = Convert.ToDateTime(linha[4]);
                    DateTime validade = Convert.ToDateTime(linha[8]);
                    string notaFiscal = linha[9].ToString();
                    string lote = linha[7].ToString();
                    string tipo = linha[6].ToString();
                    string descricao = linha[5].ToString();

                    var detalhes = new DetalhesAmostrasViewModel(idAmostra, idSolicitante, dataRecebimento, dataIdentificacao, validade, notaFiscal, lote, tipo, descricao);
                    _detalhes.ShowWindowAsync(detalhes);



                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.ToString());
                }
            }
            else
            {
                MessageBox.Show("Erro ao selecionar amostra!");
            }
        }
    }
}

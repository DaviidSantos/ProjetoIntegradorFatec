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
    public class SolicitantesViewModel : Conductor<Object>
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");
        private readonly IWindowManager _modal = new WindowManager();


        protected override void OnViewLoaded(object view)
        {
            CarregarDados();
        }

        public void CadastrarSolicitanteBotao()
        {
            var modal = new CadastroSolicitanteViewModel(this);
            _modal.ShowDialogAsync(modal);
        }

        public void Editar()
        {
            var view = this.GetView() as SolicitantesView;

            if (view.SolicitantesDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    DataRowView linha = view.SolicitantesDG.SelectedItem as DataRowView;
                    int idSolicitante = Convert.ToInt16(linha[0]);
                    string nomeSolicitante = linha[1].ToString();
                    string nomeContato = linha[2].ToString();
                    string emailContato = linha[3].ToString();

                    var modal = new EditarSolicitanteViewModel(idSolicitante, nomeSolicitante, nomeContato, emailContato, this);
                    _modal.ShowDialogAsync(modal);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Selecione um solicitante para editar!");
            }
        }

        public void CarregarDados()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Solicitantes", conexaoDB);
            DataTable dt = new DataTable();
            conexaoDB.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dt.Load(sqlDataReader);
            conexaoDB.Close();
            var view = this.GetView() as SolicitantesView;
            view.SolicitantesDG.ItemsSource = dt.DefaultView;
        }

        public void Excluir()
        {
            var view = this.GetView() as SolicitantesView;

            if (view.SolicitantesDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    DataRowView? linha = view.SolicitantesDG.SelectedItem as DataRowView;
                    conexaoDB.Open();
                    SqlCommand command = conexaoDB.CreateCommand();
                    command.CommandType = CommandType.Text;
                    var id = linha[0];
                    command.CommandText = "DELETE FROM Solicitantes WHERE idSolicitante = '" + id + "'";
                    command.ExecuteNonQuery();
                    conexaoDB.Close();
                    this.CarregarDados();
                    MessageBox.Show("Solicitante deletado com sucesso!");
                }
                catch (SqlException exception)
                {
                    MessageBox.Show("Erro ao excluir solicitante");
                }
            }
            else
            {
                MessageBox.Show("Selecione um solicitante para excluir!");
            }
            
        }
    }
}

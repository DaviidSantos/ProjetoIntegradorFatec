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
    public class ConsultaBaixaViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        protected override void OnViewLoaded(object view)
        {
            CarregarDados();
        }

        public void CarregarDados()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Baixa", conexaoDB);
            DataTable dt = new DataTable();
            conexaoDB.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dt.Load(sqlDataReader);
            conexaoDB.Close();
            var view = this.GetView() as ConsultaBaixaView;
            view.BaixaView.ItemsSource = dt.DefaultView;
        }

        public void Excluir()
        {
            var view = this.GetView() as ConsultaBaixaView;

            if (view.BaixaView.SelectedItem as DataRowView != null)
            {
                try
                {
                    conexaoDB.Open();
                    DataRowView? linha = view.BaixaView.SelectedItem as DataRowView;
                    SqlCommand command = conexaoDB.CreateCommand();
                    command.CommandType = CommandType.Text;
                    var id = linha[0];
                    command.CommandText = "DELETE FROM Baixa WHERE idAmostra = '" + id + "'";
                    command.ExecuteNonQuery();
                    conexaoDB.Close();
                    this.CarregarDados();
                    MessageBox.Show("Baixa deletada com sucesso!");
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
            else
            {
                MessageBox.Show("Selecione uma baixa para excluir");
            }

        }
    }
}

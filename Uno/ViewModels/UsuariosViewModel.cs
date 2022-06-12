using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using Uno.Views;

namespace Uno.ViewModels
{
    public class UsuariosViewModel : Conductor<object>
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");
        private readonly IWindowManager _cadastrarUsuario = new WindowManager();
        private readonly IWindowManager _editarUsuario = new WindowManager();

        protected override void OnViewLoaded(object view)
        {
            CarregarDados();
        }

 
        public void CarregarDados()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Usuarios", conexaoDB);
            DataTable dt = new DataTable();
            conexaoDB.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dt.Load(sqlDataReader);
            conexaoDB.Close();
            var view = this.GetView() as UsuariosView;
            view.UsuariosDG.ItemsSource = dt.DefaultView;
        }

        public void CadastrarUsuarioBotao()
        {
            
            var modal = new CadastroUsuarioViewModel(this);
            _cadastrarUsuario.ShowDialogAsync(modal);
        }

        public void Editar()
        {
            var view = this.GetView() as UsuariosView;

            if (view.UsuariosDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    DataRowView linha = view.UsuariosDG.SelectedItem as DataRowView;
                    int idUsuario = Convert.ToInt16(linha[0]);
                    string nomeUsuario = linha[1].ToString();
                    string cargo = linha[2].ToString();
                    string email = linha[3].ToString();
                    string senha = linha[4].ToString();

                    var modal = new EditarUsuarioViewModel(idUsuario, nomeUsuario, cargo, email, senha, this);
                    _editarUsuario.ShowDialogAsync(modal);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário para editar!");
            }
            
        }

        public void Excluir()
        {
            var view = this.GetView() as UsuariosView;

            if (view.UsuariosDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    conexaoDB.Open();
                    DataRowView? linha = view.UsuariosDG.SelectedItem as DataRowView;
                    SqlCommand command = conexaoDB.CreateCommand();
                    command.CommandType = CommandType.Text;
                    var id = linha[0];
                    command.CommandText = "DELETE FROM Usuarios WHERE idUsuario = '" + id + "'";
                    command.ExecuteNonQuery();
                    conexaoDB.Close();
                    this.CarregarDados();
                    MessageBox.Show("Usuário deletado com sucesso!");
                }
                catch (SqlException exception)
                {
                    MessageBox.Show("Erro ao excluir usuário");
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário para excluir");
            }

        }
    }
}

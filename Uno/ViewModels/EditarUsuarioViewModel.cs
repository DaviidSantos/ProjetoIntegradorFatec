using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class EditarUsuarioViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");
        private UsuariosViewModel _atualizar;

        private int _idUsuario;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _cargo;

        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }


        public EditarUsuarioViewModel(int idUsuario, string nome, string cargo, string email, string senha, UsuariosViewModel atualizar)
        {
            _idUsuario = idUsuario;
            _nome = nome;
            _cargo = cargo;
            _email = email;
            _senha = senha;
            _atualizar = atualizar;
        }

        public void Confirmar()
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Usuarios SET nome = @Nome, cargo = @Cargo, email = @Email, senha = @Senha WHERE idUsuario = @IdUsuario", conexaoDB);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Nome", _nome);
                command.Parameters.AddWithValue("@Cargo", _cargo);
                command.Parameters.AddWithValue("@Email", _email);
                command.Parameters.AddWithValue("@Senha", _senha);
                command.Parameters.AddWithValue("@IdUsuario", _idUsuario);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                _atualizar.CarregarDados();
                conexaoDB.Close();
                MessageBox.Show("Usuario alterado com sucesso!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                TryCloseAsync();
            }
            catch (SqlException exception)
            {
                MessageBox.Show("Erro ao editar usuário");
            }
        }

        public void Cancelar()
        {
            TryCloseAsync();
        }
    }
}

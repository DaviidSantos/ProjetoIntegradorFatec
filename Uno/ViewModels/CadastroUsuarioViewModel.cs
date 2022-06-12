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
    public class CadastroUsuarioViewModel : Screen
    {
        private UsuariosViewModel _atualizarDG;

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

        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        public CadastroUsuarioViewModel(UsuariosViewModel atualizarDG)
        {
            _atualizarDG = atualizarDG;
        }

        public void Cadastrar()
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Usuarios(nome, cargo, email, senha) VALUES(@Nome, @Cargo, @Email, @Senha)", conexaoDB);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Nome", _nome);
                command.Parameters.AddWithValue("@Cargo", _cargo);
                command.Parameters.AddWithValue("@Email", _email);
                command.Parameters.AddWithValue("@Senha", _senha);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                conexaoDB.Close();
                MessageBox.Show("Usuário Cadastrado com Sucesso!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                _atualizarDG.CarregarDados();
                TryCloseAsync();
            }
            catch (SqlException exception)
            {

                MessageBox.Show("Erro ao cadastrar o usuário");
            }
        }

        public void Cancelar()
        {
            TryCloseAsync();
        }
    }
}

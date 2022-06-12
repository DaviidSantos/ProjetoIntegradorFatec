using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class CadastroSolicitanteViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        private SolicitantesViewModel _atualizar;

        private string _nomeSolicitante;

        public string NomeSolicitante
        {
            get { return _nomeSolicitante; }
            set 
            { _nomeSolicitante = value;}
        }

        private string _nomeContato;

        public string NomeContato
        {
            get { return _nomeContato; }
            set 
            { _nomeContato = value;}
        }

        private string _emailContato;

        public string EmailContato
        {
            get { return _emailContato; }
            set { _emailContato = value;}
        }

        public CadastroSolicitanteViewModel(SolicitantesViewModel atualizar)
        {
            _atualizar = atualizar;
        }

        public void Cadastrar()
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Solicitantes(nomeSolicitante, nomeContato, emailContato) VALUES(@NomeSolicitante, @NomeContato, @EmailContato)", conexaoDB);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@NomeSolicitante", _nomeSolicitante);
                command.Parameters.AddWithValue("@NomeContato", _nomeContato);
                command.Parameters.AddWithValue("@EmailContato", _emailContato);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                conexaoDB.Close();
                MessageBox.Show("Solicitante Cadastrado com Sucesso!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                _atualizar.CarregarDados();
                TryCloseAsync();
            }
            catch (SqlException exception)
            {

                MessageBox.Show(exception.ToString());
            }
        }

        public void Cancelar()
        {
            TryCloseAsync();
        }
    }
}

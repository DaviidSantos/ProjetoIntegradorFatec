using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class EditarSolicitanteViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");
        private SolicitantesViewModel _solicitantesViewModel;

        private int _idSolicitante;

        public int IdSolicitante
        {
            get { return _idSolicitante; }
            set { _idSolicitante = value; }
        }

        private string _nomeSolicitante;

        public string NomeSolicitante
        { 
            get { return _nomeSolicitante; }
            set { _nomeSolicitante = value; }
        }

        private string _nomeContato;

        public string NomeContato
        {
            get { return _nomeContato; }
            set { _nomeContato = value; }
        }

        private string _emailContato;

        public string EmailContato
        {
            get { return _emailContato; }
            set { _emailContato = value; }
        }

        public EditarSolicitanteViewModel(int idSolicitante, string nomeSolicitante, string nomeContato, string emailContato, SolicitantesViewModel solicitantesViewModel)
        {
            _idSolicitante = idSolicitante;
            _nomeSolicitante = nomeSolicitante;
            _nomeContato = nomeContato;
            _emailContato = emailContato;
            _solicitantesViewModel = solicitantesViewModel;
        }

        public void Confirmar()
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Solicitantes SET nomeSolicitante = @NomeSolicitante, nomeContato = @NomeContato, emailContato = @EmailContato WHERE idSolicitante = @IdSolicitante", conexaoDB);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@NomeSolicitante", _nomeSolicitante);
                command.Parameters.AddWithValue("@NomeContato", _nomeContato);
                command.Parameters.AddWithValue("@EmailContato", _emailContato);
                command.Parameters.AddWithValue("@IdSolicitante", _idSolicitante);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                _solicitantesViewModel.CarregarDados();
                conexaoDB.Close();
                MessageBox.Show("Solicitante alterado com sucesso!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                TryCloseAsync();
            }
            catch (SqlException exception)
            {
                MessageBox.Show("Erro ao editar solicitante");
            }
        }

        public void Cancelar()
        {
            TryCloseAsync();
        }
    }
}

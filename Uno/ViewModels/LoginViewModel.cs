using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class LoginViewModel : Conductor<object>
    {
        private readonly IWindowManager _shellView = new WindowManager();
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set 
            { 
                _senha = value;
                NotifyOfPropertyChange(() => Senha);
            }
        }



        public void Login()
        {
            conexaoDB.Open();
            string query = "SELECT * FROM Usuarios WHERE email = '"+ _email +"' AND senha = '"+_senha+"' ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexaoDB);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                var ShellViewModel = new ShellViewModel();
                _shellView.ShowWindowAsync(ShellViewModel);
                this.TryCloseAsync();
            }
            else
            {
                MessageBox.Show("Email ou senha incorreto!");
            }
            conexaoDB.Close();
        }
    }
}

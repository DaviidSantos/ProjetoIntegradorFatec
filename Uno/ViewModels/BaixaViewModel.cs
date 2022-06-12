using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class BaixaViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        private AmostrasViewModel _atualizar;

        private int _idAmostra;

        public int IdAmostra
        {
            get { return _idAmostra; }
            set 
            { 
                _idAmostra = value;
                NotifyOfPropertyChange(() => IdAmostra);
            }
        }

        private DateTime? _dataBaixa;

        public DateTime? DataBaixa
        {
            get { return _dataBaixa; }
            set 
            { 
                _dataBaixa = value;
                NotifyOfPropertyChange(() => DataBaixa);
            }
        }

        private string _motivoBaixa;

        public string MotivoBaixa
        {
            get { return _motivoBaixa; }
            set
            { 
                _motivoBaixa = value;
                NotifyOfPropertyChange(() => MotivoBaixa);
            }
        }

        public BaixaViewModel(AmostrasViewModel atualizar)
        {
            _atualizar = atualizar;
        }

        public void Confirmar()
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Baixa(idAmostra, dataBaixa, motivoBaixa) VALUES(@IdAmostra, @DataBaixa, @MotivoBaixa)", conexaoDB);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@IdAmostra", _idAmostra);
                command.Parameters.AddWithValue("@DataBaixa", _dataBaixa);
                command.Parameters.AddWithValue("@MotivoBaixa", _motivoBaixa);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                conexaoDB.Close();
                MessageBox.Show("Baixa efetuada com sucesso!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                command.CommandText = "DELETE FROM RecebimentoAmostras WHERE idAmostra = '" + _idAmostra + "'";
                conexaoDB.Open();
                command.ExecuteNonQuery();
                conexaoDB.Close();
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

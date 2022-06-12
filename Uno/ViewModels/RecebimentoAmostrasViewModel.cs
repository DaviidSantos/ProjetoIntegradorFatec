using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace Uno.ViewModels
{
    public class RecebimentoAmostrasViewModel : Screen
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        private int? _idSolicitante;

        public int? IdSolicitante
        {
            get { return _idSolicitante; }
            set
            { 
                _idSolicitante = value;
                NotifyOfPropertyChange(() => IdSolicitante);
            }
        }
                
        private int? _numSA;

        public int? NumSA
        {
            get { return _numSA; }
            set
            { 
                _numSA = value;
                NotifyOfPropertyChange(() => NumSA);
            }
        }


        private DateTime? _dataRecebimento;

        public DateTime? DataRecebimento
        {
            get { return _dataRecebimento; }
            set
            { 
                _dataRecebimento = value; 
                NotifyOfPropertyChange(() => DataRecebimento);
            }
        }

        private DateTime? _dataIdentificacao;

        public DateTime? DataIdentificacao
        {
            get { return _dataIdentificacao; }
            set 
            { 
                _dataIdentificacao = value;
                NotifyOfPropertyChange(() => DataIdentificacao);
            }
        }

        private string? _notaFiscal;

        public string? NotaFiscal
        {
            get { return _notaFiscal; }
            set 
            { 
                _notaFiscal = value;
                NotifyOfPropertyChange(() => NotaFiscal);
            }
        }

        private string? _tipo;

        public string? Tipo
        {
            get { return _tipo; }
            set 
            { 
                _tipo = value;
                NotifyOfPropertyChange(() => Tipo);
            }
        }

        private string? _lote;

        public string? Lote
        {
            get { return _lote; }
            set
            { 
                _lote = value;
                NotifyOfPropertyChange(() => Lote);
            }
        }

        private DateTime? _validade;

        public DateTime? Validade
        {
            get { return _validade; }
            set
            { 
                _validade = value;
                NotifyOfPropertyChange(() => Validade);
            }
        }

        private string? _descricao;

        public string? Descricao
        {
            get { return _descricao; }
            set 
            {
                _descricao = value;
                NotifyOfPropertyChange(() => Descricao);
            }
        }

        public void Cadastrar()
        {
            try
            {
                SqlCommand command =
              new SqlCommand(
                  "INSERT INTO RecebimentoAmostras(idSolicitante, numSA, dataRecebimento, dataIdentificacao, descricao, tipo, lote, validade, notaFiscal) VALUES(@IdSolicitante, @NumSA, @DataRecebimento, @DataIdentificacao, @Descricao, @Tipo, @Lote, @Validade, @NotaFiscal)", conexaoDB);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@IdSolicitante", _idSolicitante);
                command.Parameters.AddWithValue("@NumSA", _numSA);
                command.Parameters.AddWithValue("@DataRecebimento", _dataRecebimento);
                command.Parameters.AddWithValue("@DataIdentificacao", _dataIdentificacao);
                command.Parameters.AddWithValue("@Descricao", _descricao);
                command.Parameters.AddWithValue("@Tipo", _tipo);
                command.Parameters.AddWithValue("@Lote", _lote);
                command.Parameters.AddWithValue("@Validade", _validade);
                command.Parameters.AddWithValue("@NotaFiscal", _notaFiscal);
                conexaoDB.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Amostra cadastrada com sucesso");

                IdSolicitante = null;
                NumSA = null;
                DataRecebimento = null;
                DataIdentificacao = null;
                Descricao = null;
                Tipo = null;
                Lote = null;
                Validade = null;
                NotaFiscal = null;

            }
            catch (SqlException exception)
            {

                MessageBox.Show("Erro ao cadastrar amostra!");
            }
            finally
            {
                conexaoDB.Close();
            }
        }

        public void Cancelar()
        {
            IdSolicitante = null;
            NumSA = null;
            DataRecebimento = null;
            DataIdentificacao = null;
            Descricao = null;
            Tipo = null;
            Lote = null;
            Validade = null;
            NotaFiscal = null;
        }

    }
}

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using Uno.Views;

namespace Uno.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private Screen _telaSelecionada = new AnalisesViewModel();
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set 
            { 
                _nome = value;
                NotifyOfPropertyChange(() => Nome);
            }
        }

        private string _cargo;

        public string Cargo
        {
            get { return _cargo; }
            set 
            {
                _cargo = value; 
                NotifyOfPropertyChange(() => Cargo);
            }
        }



        public Screen TelaSelecionada
        {
            get { return _telaSelecionada; }
            set 
            { 
                _telaSelecionada = value; 
                NotifyOfPropertyChange(() => TelaSelecionada);
            }
        }

        public ShellViewModel()
        {
            
        }

        public void Analises()
        {
            TelaSelecionada = new AnalisesViewModel();
        }

        public void Amostras()
        {
            TelaSelecionada = new AmostrasViewModel();
        }

        public void Solicitantes()
        {
            TelaSelecionada = new SolicitantesViewModel();
        }

        public void RecebimentoAmostras()
        {
            TelaSelecionada = new RecebimentoAmostrasViewModel();
        }

        public void SolicitacaoAnalise()
        {
            TelaSelecionada = new SolicitacaoAnaliseViewModel();
        }

        public void Usuarios()
        {
            TelaSelecionada = new UsuariosViewModel();
        }

        public void Resultados()
        {
            TelaSelecionada = new ResultadosAnalisesViewModel();
        }

        public void ConsultaResultados()
        {
            TelaSelecionada = new ConsultaResultadosViewModel();
        }

        public void Baixa()
        {
            TelaSelecionada = new ConsultaBaixaViewModel();
        }
    }
}

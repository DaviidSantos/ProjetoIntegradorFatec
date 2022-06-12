using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uno.Views
{
    /// <summary>
    /// Interaction logic for UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        SqlConnection conexaoDB = new SqlConnection(@"Data Source=LAPTOP-6FG4GI0V;Initial Catalog=UnoLIMS;Integrated Security=True");

        public UsuariosView()
        {
            InitializeComponent();
        }

       

        
    }
}

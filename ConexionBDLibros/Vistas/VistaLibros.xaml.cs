using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConexionBDLibros.Vistas
{
    /// <summary>
    /// Interaction logic for VistaLibros.xaml
    /// </summary>
    public partial class VistaLibros : UserControl
    {

        public Conexion Conexion = new Conexion();
        public VistaLibros()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (boxTituloLibro.Text != null)
            {
                Conexion.NuevoLibro(boxTituloLibro.Text);
                RecargarTabla();
            }
            else
            {
                MessageBox.Show("Los Campos no pueden quedar vacios","Advertencia");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TablaLibros.ItemsSource = Conexion.listarLibros().DefaultView;
        }

        private void RecargarTabla()
        {
            TablaLibros.ItemsSource = null;
            TablaLibros.ItemsSource = Conexion.listarLibros().DefaultView;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for VistaPedidos.xaml
    /// </summary>
    public partial class VistaPedidos : UserControl
    {
        public Conexion Conexion = new Conexion();
        public VistaPedidos()
        {
            InitializeComponent();
        }

        private void boxNombreCliente_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, "\\d"))
            {
                e.Handled = true;
            }
        }

        private void boxApellidoCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, "\\d"))
            {
                e.Handled = true;
            }
        }

        private void boxCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, "\\D"))
            {
                e.Handled = true;
            }
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (boxApellidoCliente.Text != null && boxNombreCliente.Text != null && boxTituloLibro.Text != null && boxCantidad != null)
            {
                Conexion.NuevoPedido(boxNombreCliente.Text,boxApellidoCliente.Text,boxTituloLibro.Text,int.Parse(boxCantidad.Text));
                RecargarTabla();
            }
            else
            {
                MessageBox.Show("Los campos no pueden quedar vacios","Advertencia");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TablaPedidos.ItemsSource = Conexion.listarPedidos().DefaultView;
        }

        private void RecargarTabla()
        {
            TablaPedidos.ItemsSource = null;
            TablaPedidos.ItemsSource = Conexion.listarPedidos().DefaultView;
        }
    }
}

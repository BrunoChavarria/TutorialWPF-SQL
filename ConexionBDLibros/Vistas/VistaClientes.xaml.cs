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
    /// Interaction logic for VistaClientes.xaml
    /// </summary>
    public partial class VistaClientes : UserControl
    {
        public Conexion Conexion = new Conexion();
        public VistaClientes()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (boxNombreCliente.Text != null && boxApellidoCliente.Text !=null)
            {
                Conexion.NuevoCliente(boxNombreCliente.Text, boxApellidoCliente.Text);
                RecargarTabla();
            }
            else
            {
                MessageBox.Show("Los Campos no pueden Quedar Vacios","Advertencia");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //
            TablaClientes.ItemsSource = Conexion.listarClientes().DefaultView;
        }

        private void RecargarTabla()
        {
            TablaClientes.ItemsSource = null;
            TablaClientes.ItemsSource = Conexion.listarClientes().DefaultView;
        }

        private void boxNombreCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
    }
}

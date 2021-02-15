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

namespace ConexionBDLibros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void AbrirClientes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            setActiveControl(VistaClientes);
        }

        private void AbrirLibros_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            setActiveControl(VistaLibros);
        }

        private void AbrirPedidos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            setActiveControl(VistaPedidos);
        }

        private void btnCerrarVistas_Click(object sender, RoutedEventArgs e)
        {
            VistaClientes.Visibility = Visibility.Hidden;
            VistaLibros.Visibility = Visibility.Hidden;
            VistaPedidos.Visibility = Visibility.Hidden;

            AbrirClientes.IsSelected = false;
            AbrirLibros.IsSelected = false;
            AbrirPedidos.IsSelected = false;
        }

        private void setActiveControl (UserControl control)
        {
            VistaClientes.Visibility = Visibility.Hidden;
            VistaLibros.Visibility = Visibility.Hidden;
            VistaPedidos.Visibility = Visibility.Hidden;

            control.Visibility = Visibility.Visible;
        }
    }
}

using System.Windows;
using VisualizaClientes.ViewModel;

namespace VisualizaClientes.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ClientesViewModel();
        }
    }
}

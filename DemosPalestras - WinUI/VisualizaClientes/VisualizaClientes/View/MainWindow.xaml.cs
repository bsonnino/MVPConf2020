using System;
using System.Windows;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
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

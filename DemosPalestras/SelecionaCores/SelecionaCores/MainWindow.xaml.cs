using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SelecionaCores
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

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            if (slider == null)
                return;
            MudaPreenchimento();
        }

        private void MudaPreenchimento()
        {
            var cor = Color.FromRgb(Convert.ToByte(SliderR.Value), Convert.ToByte(SliderG.Value), 
                Convert.ToByte(SliderB.Value));
            RectExemplo.Fill = new SolidColorBrush(cor);
        }
    }
}

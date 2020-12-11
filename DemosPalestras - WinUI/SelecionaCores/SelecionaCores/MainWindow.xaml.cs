using System;
using System.Windows;
using System.Windows.Media;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Wpf.UI.XamlHost;

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

        private void WindowsXamlHostBase_OnChildChanged(object sender, EventArgs e)
        {
            var colorPicker = (ColorPicker) (sender as WindowsXamlHost)?.Child;
            if (colorPicker == null) return;
            colorPicker.ColorSpectrumShape = ColorSpectrumShape.Ring;
            colorPicker.ColorChanged += ColorPicker_ColorChanged;
        }

        private void ColorPicker_ColorChanged(Windows.UI.Xaml.Controls.ColorPicker sender, Windows.UI.Xaml.Controls.ColorChangedEventArgs args)
        {
            var cor = Color.FromArgb(args.NewColor.A, args.NewColor.R, args.NewColor.G, args.NewColor.B);
            RectExemplo.Fill = new SolidColorBrush(cor);
        }
    }
}

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace RiotClient.CustomControl
{
    /// <summary>
    /// Interaction logic for WatermarkTextBox.xaml
    /// </summary>
    public partial class WatermarkTextBox : UserControl
    {
        public WatermarkTextBox()
        {
            InitializeComponent();
        }

        public string LabelMark
        {
            get { return (string)GetValue(LabelMarkProperty); }
            set { SetValue(LabelMarkProperty, value); }
        }

        public static readonly DependencyProperty LabelMarkProperty =
            DependencyProperty.Register("LabelMark", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(string.Empty));

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var animation = new ThicknessAnimation(new Thickness(5, -27, 5, 0), TimeSpan.FromSeconds(0.2));
            watermarkTB.BeginAnimation(Label.MarginProperty, animation);
            watermarkTB.BeginAnimation(Label.FontSizeProperty, new DoubleAnimation(12, TimeSpan.FromSeconds(0.2)));

            watermarkTB.Foreground = Brushes.Gray;
            watermarkTB.FontWeight = FontWeights.Bold;

            border.BorderBrush = Brushes.Gray;
            border.BorderThickness = new Thickness(2.5);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                var animation = new ThicknessAnimation(new Thickness(15, 0, 0, 0), TimeSpan.FromSeconds(0.2));
                watermarkTB.BeginAnimation(Label.MarginProperty, animation);
                watermarkTB.BeginAnimation(Label.FontSizeProperty, new DoubleAnimation(14, TimeSpan.FromSeconds(0.2)));
                watermarkTB.Foreground = Brushes.Gray;
                watermarkTB.FontWeight = FontWeights.Normal;
            }
            border.BorderBrush = Brushes.Gray;
            border.BorderThickness = new Thickness(0);
        }
    }
}

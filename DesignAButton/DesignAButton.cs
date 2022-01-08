using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Petzold.DesignAButton {
    internal class DesignAButton : Window {
        [STAThread]
        public static void Main() { new Application().Run(new DesignAButton()); }
        public DesignAButton() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick;
            Content = btn;

            StackPanel stack = new StackPanel();
            btn.Content = stack;

            stack.Children.Add(ZigZag(10));

            Uri uri = new Uri("pack://application:,,/icon.ico");
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            img.Margin = new Thickness(0, 0, 0, 0);
            img.Source = bitmap;
            img.Stretch = Stretch.None;
            stack.Children.Add(img);

            Label label = new Label();
            label.Content = "_Read books!";
            label.HorizontalAlignment = HorizontalAlignment.Center;
            stack.Children.Add(label);

            stack.Children.Add(ZigZag(0));

        }

        private void ButtonOnClick(object sender, RoutedEventArgs e) {
            Title = $"{DateTime.Now}";
        }

        private Polyline ZigZag(int offset) {
            Polyline poly = new Polyline();
            poly.Stroke = SystemColors.ControlTextBrush;
            poly.Points = new PointCollection();
            for (int i = 0; i <= 100; i += 10) {
                poly.Points.Add(new Point(i, (i + offset) % 20));
            }
            return poly;
        }
    }
}

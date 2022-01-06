using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.ImageTheButton {
    internal class ImageTheButton : Window {
        [STAThread]
        public static void Main() { new Application().Run(new ImageTheButton()); }
        public ImageTheButton() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            //button.Image = new BitmapImage(new Uri("pack://application:,,,/CPI Sheets Updater;component/Resources/toggle-on-16.png"));
            var uri = new Uri("pack://application:,,,/ImageTheButton;component/Resources/munch.png");
            BitmapImage bm = new BitmapImage(uri);
            Image img = new Image();
            img.Source = bm;
            img.Stretch = Stretch.None;

            var btn = new Button();
            btn.Content = img;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;

            Content = btn;

            var t = new ToolTip();
            t.Content = img;
            btn.ToolTip = t;
        }
    }
}

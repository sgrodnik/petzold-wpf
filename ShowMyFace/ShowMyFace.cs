using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.ShowMyFace {
    internal class ShowMyFace : Window {
        [STAThread]
        public static void Main() { new Application().Run(new ShowMyFace()); }
        public ShowMyFace() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var uri = new Uri("http://www.charlespetzold.com/PetzoldTattoo.jpg");
            //Uri uri = new Uri( System.IO.Path.Combine(
            //    Environment.GetEnvironmentVariable("windir"),"Gone Fishing.bmp")); 

            BitmapImage bm = new BitmapImage(uri);
            Image img = new Image();
            img.Source = bm;
            Content = img;
            img.Stretch = Stretch.None;
            img.HorizontalAlignment = HorizontalAlignment.Right;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.Margin = new Thickness(11);
            img.Opacity = .5;
            Background = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(1, 1));
            img.LayoutTransform = new RotateTransform(45);
        }
    }
}

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DisplaySomeText {
    internal class DisplaySomeText : Window {
        [STAThread]
        public static void Main() { new Application().Run(new DisplaySomeText()); }
        public DisplaySomeText() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Content = "123 456";
            FontFamily = new FontFamily("Comic Sans MS");
            FontSize = 48;
            
            Brush br = new LinearGradientBrush(Colors.Black, Colors.White, new Point(0, 0), new Point(1, 1));
            Background = Foreground = br;

            SizeToContent = SizeToContent.WidthAndHeight;
            //ResizeMode = ResizeMode.CanMinimize;
            BorderBrush = Brushes.White;
            BorderThickness = new Thickness(11);

            Content = Math.PI;
        }
    }
}

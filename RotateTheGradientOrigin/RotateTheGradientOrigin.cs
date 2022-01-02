using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Petzold.RotateTheGradientOrigin {
    internal class RotateTheGradientOrigin : Window {
        RadialGradientBrush br;
        double angle;
        [STAThread]
        public static void Main() { new Application().Run(new RotateTheGradientOrigin()); }
        public RotateTheGradientOrigin() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            //WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Top = 0;
            Left = 0;
            Width = Height = 384;

            br = new RadialGradientBrush(Colors.White, Colors.Blue);
            br.Center = br.GradientOrigin = new Point(.5, .5);
            br.RadiusX = br.RadiusY = .1;
            br.SpreadMethod = GradientSpreadMethod.Repeat;
            Background = br;

            var tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromMilliseconds(30);
            tmr.Tick += TimerOnTick;
            tmr.Start();

            //BorderBrush = Brushes.SaddleBrown;
            BorderBrush = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(), new Point(1, 1));
            BorderThickness = new Thickness(25, 50, 0, 100);
        }

        private void TimerOnTick(object sender, EventArgs e) {
            var pt = new Point(.5 + .05 * Math.Cos(angle), .5 + .05 * Math.Sin(angle));
            br.GradientOrigin = pt;
            angle += Math.PI / 60;
        }
    }
}

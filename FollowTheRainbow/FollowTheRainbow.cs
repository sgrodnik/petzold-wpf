using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.FollowTheRainbow {
    internal class FollowTheRainbow : Window {
        [STAThread]
        public static void Main() {
            new Application().Run(new FollowTheRainbow());
        }
        public FollowTheRainbow() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";

            //var br = new LinearGradientBrush();
            //br.StartPoint = new Point(0, 0);
            //br.EndPoint = new Point(1, 0);
            var br = new RadialGradientBrush();
            Background = br;

            br.GradientStops.Add(new GradientStop(Colors.Red, 0));
            br.GradientStops.Add(new GradientStop(Colors.Orange, .17));
            br.GradientStops.Add(new GradientStop(Colors.Yellow, .33));
            br.GradientStops.Add(new GradientStop(Colors.Green, .5));
            br.GradientStops.Add(new GradientStop(Colors.Blue, .67));
            br.GradientStops.Add(new GradientStop(Colors.Indigo, .84));
            br.GradientStops.Add(new GradientStop(Colors.Violet, 1));
        }
    }
}

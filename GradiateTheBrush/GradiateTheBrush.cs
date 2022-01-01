using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.GradiateTheBrush {
    internal class GradiateTheBrush : Window {
        [STAThread]
        public static void Main() {
            new Application().Run(new GradiateTheBrush());
        }
        public GradiateTheBrush() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var br = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(.25, .25));
            Background = br;
            br.SpreadMethod = GradientSpreadMethod.Reflect;
        }
    }
}

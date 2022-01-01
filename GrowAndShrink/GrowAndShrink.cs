using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.GrowAndShrink {
    internal class GrowAndShrink : Window {
        [STAThread]
        public static void Main() {
            new Application().Run(new GrowAndShrink());
        }
        public GrowAndShrink() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Width = 192;
            Height = 192;
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            if (e.Key == Key.Up) {
                Left -= .05 * Width;
                Top -= .05 * Height;
                Width *= 1.1;
                Height *= 1.1;
            } else if (e.Key == Key.Down) {
                Left += .05 * (Width /= 1.1);
                Top += .05 * (Height /= 1.1);
            }
        }
    }
}

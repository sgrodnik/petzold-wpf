using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ToggleTheButton {
    internal class ToggleTheButton : Window {
        [STAThread]
        public static void Main() { new Application().Run(new ToggleTheButton()); }
        public ToggleTheButton() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var btn = new CheckBox();
            btn.Content = "Can _resize";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.IsChecked = (ResizeMode == ResizeMode.CanResize);
            btn.Checked += ButtonOnChecked;
            btn.Unchecked += ButtonOnChecked;
            Content = btn;
        }

        private void ButtonOnChecked(object sender, RoutedEventArgs e) {
            ToggleButton btn = (ToggleButton)sender;
            ResizeMode = (bool)btn.IsChecked ? ResizeMode.CanResize : ResizeMode.NoResize;
        }
    }
}

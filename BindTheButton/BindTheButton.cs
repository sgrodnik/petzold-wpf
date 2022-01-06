using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.BindTheButton {
    internal class BindTheButton : Window {
        [STAThread]
        public static void Main() { new Application().Run(new BindTheButton()); }
        public BindTheButton() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var b = new ToggleButton();
            b.Content = "Make _Topmost";
            b.HorizontalAlignment = HorizontalAlignment.Center;
            b.VerticalAlignment = VerticalAlignment.Center;
            b.SetBinding(ToggleButton.IsCheckedProperty, "Topmost");
            b.DataContext = this;
            Content = b;

            var t = new ToolTip();
            t.Content = "Toggle the button on to make " +
                "the window topmost on the desktop";
            b.ToolTip = t;
        }
    }
}

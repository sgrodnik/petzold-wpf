using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.UriDialog {
    class UriDialog : Window {
        TextBox tb;
        public static void Main() { new Application().Run(new UriDialog()); }
        public UriDialog() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            ShowInTaskbar = false;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            tb = new TextBox();
            tb.Margin = new Thickness(48);
            Content = tb;

            tb.Focus();
        }
        public string Text {
            set {
                tb.Text = value;
                tb.SelectionStart = tb.Text.Length;
            }
            get { return tb.Text; }
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            if (e.Key == Key.Enter) { Close(); }
        }
    }

}

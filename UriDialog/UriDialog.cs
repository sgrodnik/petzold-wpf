using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.UriDialog {
    internal class UriDialog : Window {
        [STAThread]
        public static void Main() { new Application().Run(new UriDialog()); }
        public UriDialog() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
        }
    }
}

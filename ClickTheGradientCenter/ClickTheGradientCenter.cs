using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ClickTheGradientCenter {
    internal class ClickTheGradientCenter : Window {
        [STAThread]
        public static void Main() {
            new Application().Run(new ClickTheGradientCenter());
        }
        public ClickTheGradientCenter() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
        }
    }
}

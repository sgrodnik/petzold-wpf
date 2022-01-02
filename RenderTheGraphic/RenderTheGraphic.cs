using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.RenderTheGraphic {
    internal class RenderTheGraphic : Window {
        [STAThread]
        public static void Main() { new Application().Run(new RenderTheGraphic()); }
        public RenderTheGraphic() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            SimpleEllipse se = new SimpleEllipse();
            Content = se;
        }
    }
}

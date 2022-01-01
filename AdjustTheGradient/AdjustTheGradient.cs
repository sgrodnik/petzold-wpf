using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.AdjustTheGradient {
    internal class AdjustTheGradient : Window {
        LinearGradientBrush br;
        [STAThread]
        public static void Main() {
            new Application().Run(new AdjustTheGradient());
        }
        public AdjustTheGradient() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            SizeChanged += WindowOnSizeChanged;
            br = new LinearGradientBrush(Colors.Red, Colors.Blue, 0);
            br.MappingMode = BrushMappingMode.Absolute;
            Background = br;
        }

        private void WindowOnSizeChanged(object sender, SizeChangedEventArgs e) {
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight
                - SystemParameters.CaptionHeight;

            Point ptCenter = new Point(width / 2, height / 2);
            Vector vDiag = new Vector(width, -height);
            Vector vPerp = new Vector(vDiag.Y, -vDiag.X);
            vPerp.Normalize();
            vPerp *= width * height / vDiag.Length;
            br.StartPoint = ptCenter + vPerp;
            br.EndPoint = ptCenter - vPerp;
        }
    }
}

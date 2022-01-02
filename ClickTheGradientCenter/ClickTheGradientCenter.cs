using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ClickTheGradientCenter {
    internal class ClickTheGradientCenter : Window {
        RadialGradientBrush br;
        Point ptMouse;
        double width;
        double height;
        [STAThread]
        public static void Main() {
            new Application().Run(new ClickTheGradientCenter());
        }
        public ClickTheGradientCenter() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            br = new RadialGradientBrush(Colors.White, Colors.Red);
            br.RadiusX = br.RadiusY = .1;
            br.SpreadMethod = GradientSpreadMethod.Repeat;
            Background = br;
        }
        protected override void OnMouseDown(MouseButtonEventArgs e) {
            base.OnMouseDown(e);
            width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight
                - SystemParameters.CaptionHeight;
            ptMouse = e.GetPosition(this);
            ptMouse.X /= width;
            ptMouse.Y /= height;
            if (e.ChangedButton == MouseButton.Left) {
                br.Center = ptMouse;
                br.GradientOrigin = ptMouse;
            } else if (e.ChangedButton == MouseButton.Right) {
                br.GradientOrigin = ptMouse;
            }
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e) {
            base.OnMouseWheel(e);
            if (e.Delta > 0) {
                br.RadiusX = br.RadiusY -= .01;
            } else {
                br.RadiusX = br.RadiusY += .01;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            ptMouse = e.GetPosition(this);
            ptMouse.X /= width;
            ptMouse.Y /= height;
            br.GradientOrigin = ptMouse;
        }
    }
}

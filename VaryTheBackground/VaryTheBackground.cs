using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.VaryTheBackground {
    internal class VaryTheBackground : Window {
        SolidColorBrush brush = new SolidColorBrush(Colors.Black);
        [STAThread]
        public static void Main() {
            new Application().Run(new VaryTheBackground());
        }
        public VaryTheBackground() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Width = 384;
            Height = 384;
            Background = brush;
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight;

            Point ptMouse = e.GetPosition(this);
            Point ptCenter = new Point(width / 2, height / 2);
            Vector vectMouse = ptMouse - ptCenter;
            double angle = Math.Atan2(vectMouse.Y, vectMouse.X);
            Vector vectEllipse = new Vector(width / 2 * Math.Cos(angle), height / 2 * Math.Sin(angle));
            Byte byLevel = (byte)(255 * (1 - Math.Min(1, vectMouse.Length / vectEllipse.Length)));
            Color clr = brush.Color;
            //clr.R = clr.G = clr.B = byLevel;
            clr.R = clr.G = clr.B = byLevel;
            clr.R = (byte)(255 * (vectMouse.X / (width / 2)));
            clr.G = (byte)(255 * (vectMouse.Y / (height / 2)));
            brush.Color = clr;
            Title = $"{ptMouse} / {vectMouse} / {angle} / {vectEllipse} / {byLevel} / {clr}";
            //Title = $"{clr.R}";
            //angle = (angle) / (3.14159) * 90;
            Title = $"{angle}          {new Point(Math.Cos(angle), Math.Sin(angle))}";
            var br = new LinearGradientBrush(Colors.Aqua, Colors.Bisque, new Point(0,0), new Point(Math.Cos(angle), Math.Sin(angle)));
            Background = br;
        }
    }
}

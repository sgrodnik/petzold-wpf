using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.FlipThroughTheBrushes {
    internal class FlipThroughTheBrushes : Window {
        int index = 0;
        PropertyInfo[] props;
        [STAThread]
        public static void Main() {
            new Application().Run(new FlipThroughTheBrushes());
        }
        public FlipThroughTheBrushes() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            SetTitleAndBackgound();
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            if (e.Key == Key.Down || e.Key == Key.Up) {
                index += e.Key == Key.Up ? 1 : props.Length - 1;
                index %= props.Length;
                SetTitleAndBackgound();
            }
        }

        private void SetTitleAndBackgound() {
            Title = props[index].Name;
            Background = (Brush) props[index].GetValue(null, null);
            //Background = new SolidColorBrush(SystemColors.WindowColor);
        }
    }
}

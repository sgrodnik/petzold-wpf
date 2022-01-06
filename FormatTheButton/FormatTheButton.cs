using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.FormatTheButton {
    internal class FormatTheButton : Window {
        Run runButton;
        [STAThread]
        public static void Main() { new Application().Run(new FormatTheButton()); }
        public FormatTheButton() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.MouseEnter += ButtonOnMouseEnter;
            btn.MouseLeave += ButtonOnMouseLeave;
            btn.Padding = new Thickness(10);
            Content = btn;

            var tb = new TextBlock();
            tb.FontSize = 24;
            tb.TextAlignment = TextAlignment.Center;
            btn.Content = tb;

            tb.Inlines.Add(new Italic(new Run("Click")));
            tb.Inlines.Add(" the ");
            tb.Inlines.Add(runButton = new Run("button"));
            tb.Inlines.Add(new LineBreak());
            tb.Inlines.Add("to launch the ");
            tb.Inlines.Add(new Bold(new Run("rocket")));

        }

        private void ButtonOnMouseLeave(object sender, MouseEventArgs e) {
            //runButton.Foreground = SystemColors.ControlTextBrush;
            runButton.Foreground = Brushes.Beige;
        }

        private void ButtonOnMouseEnter(object sender, MouseEventArgs e) {
            runButton.Foreground = Brushes.Red;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Reflection;

namespace Petzold.ToggleBoldAndItalic {
    internal class ToggleBoldAndItalic : Window {
        [STAThread]
        public static void Main() { new Application().Run(new ToggleBoldAndItalic()); }
        public ToggleBoldAndItalic() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var text = new TextBlock();
            text.FontSize = 32;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            Content = text;

            var quote = "To be, or not to be, that is the question";
            string[] words = quote.Split();

            foreach (string word in words) {
                Run run = new Run(word);
                run.MouseDown += RunOnMouseDown;
                text.Inlines.Add(run);
                text.Inlines.Add(" ");
            }
        }

        private void RunOnMouseDown(object sender, MouseButtonEventArgs e) {
            var run = sender as Run;
            if (e.ChangedButton == MouseButton.Left) {
                run.FontStyle = run.FontStyle == FontStyles.Italic ?
                    FontStyles.Normal : FontStyles.Italic;
            }
            if (e.ChangedButton == MouseButton.Right) {
                run.FontWeight = run.FontWeight == FontWeights.Bold ?
                    FontWeights.Normal : FontWeights.Bold;
            }
        }
    }
}
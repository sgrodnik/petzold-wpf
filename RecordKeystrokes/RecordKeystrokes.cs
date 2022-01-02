using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Text;

namespace Petzold.RecordKeystrokes {
    internal class RecordKeystrokes : Window {
        StringBuilder sb = new StringBuilder("text");
        [STAThread]
        public static void Main() { new Application().Run(new RecordKeystrokes()); }
        public RecordKeystrokes() {
            //Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Title = sb.ToString();
            Content = sb;
        }
        protected override void OnTextInput(TextCompositionEventArgs e) {
            base.OnTextInput(e);
            //var str = Content as string;
            if (e.Text == "\b") {
                if (sb.Length > 0) {
                    sb.Remove(sb.Length - 1, 1);
                }
            } else {
                sb.Append(e.Text);
            }
                Content = null;
                Content = sb;
        }
    }
}

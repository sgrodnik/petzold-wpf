using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Reflection;

namespace Petzold.FormatTheText {
    internal class FormatTheText : Window {
        [STAThread]
        public static void Main() { new Application().Run(new FormatTheText()); }
        public FormatTheText() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            var tb = new TextBlock();
            tb.FontSize = 32;
            tb.Inlines.Add("qwe qwe йцу 123");
            tb.Inlines.Add(new Italic(new Run("italic")));
            Content = tb;
        }
    }
}

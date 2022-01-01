using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.TypeYourTitle {
    internal class TypeYourTitle : Window {
        [STAThread]
        public static void Main() {
            new Application().Run(new TypeYourTitle());
        }
        public TypeYourTitle() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
        }
        protected override void OnTextInput(TextCompositionEventArgs e) {
            base.OnTextInput(e);
            if (e.Text == "\b" && Title.Length > 0) {
                Title = Title.Substring(0, Title.Length - 1);
            } else if (e.Text.Length > 0 && !Char.IsControl(e.Text[0])) {
                Title += e.Text;
            }
        }
    }
}

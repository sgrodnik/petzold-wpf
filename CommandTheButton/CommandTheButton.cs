using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.CommandTheButton {
    internal class CommandTheButton : Window {
        [STAThread]
        public static void Main() { new Application().Run(new CommandTheButton()); }
        public CommandTheButton() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Command = ApplicationCommands.Paste;
            btn.Content = ApplicationCommands.Paste.Text;
            Content = btn;

            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Paste, PasteOnExecute, PasteCanExecute));
        }

        private void PasteCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void PasteOnExecute(object sender, ExecutedRoutedEventArgs e) {
            Title = Clipboard.GetText();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e) {
            base.OnMouseDown(e);
            Title = "1 1 1 1 1 1 1 1 1 1 1 2";
        }
    }
}

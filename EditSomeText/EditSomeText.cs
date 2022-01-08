using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.EditSomeText {
    internal class EditSomeText : Window {
        static string file = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData),
            "Petzold\\EditSomeText\\text.txt");
        TextBox t;
        [STAThread]
        public static void Main() { new Application().Run(new EditSomeText()); }
        public EditSomeText() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            t = new TextBox();
            t.AcceptsReturn = true;
            t.TextWrapping = TextWrapping.Wrap;
            t.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            t.KeyDown += TextBoxKeyDown;
            Content = t;
            try {
                t.Text = File.ReadAllText(file);
            } catch {
            }
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.F5) {
                t.SelectedText = DateTime.Now.ToString();
                t.CaretIndex = t.SelectionStart + t.SelectionLength;
            };
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            try {
                Directory.CreateDirectory(Path.GetDirectoryName(file));
                File.WriteAllText(file, t.Text);
            } catch (Exception ex) {
                var result = 
                    MessageBox.Show("File could not be saved: " +
                        "" +
                        "\nClose anyway?", Title, MessageBoxButton.YesNo,
                        MessageBoxImage.Exclamation);
                e.Cancel = (result == MessageBoxResult.No);
            }
        }
    }
}

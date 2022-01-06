using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.UriDialog {
    class NavigateTheWeb : Window {
        Frame f;
        [STAThread]
        public static void Main() { new Application().Run(new NavigateTheWeb()); }

        public NavigateTheWeb() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            f = new Frame();
            Content = f;
            Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e) {
            UriDialog d = new UriDialog();
            d.Owner = this;
            d.Text = "http://";
            d.ShowDialog();
            try {
                f.Source = new Uri(d.Text);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Title);
            }
        }
    }
}

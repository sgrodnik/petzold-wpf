using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.StackTenButtons {
    internal class StackTenButtons : Window {
        [STAThread]
        public static void Main() { new Application().Run(new StackTenButtons()); }
        public StackTenButtons() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            StackPanel stack = new StackPanel();
            Content = stack;
            Random rand = new Random();
            for (int i = 0; i < 10; i++) {
                Button btn = new Button();
                btn.Name = ((char)('A' + i)).ToString();
                var r = rand.Next(10);
                btn.FontSize += r;
                btn.Content = $"Button {btn.Name} says 'Click me' {r}";
                //btn.Click += ButtonClick;
                stack.Children.Add(btn);
                //btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.Margin = new Thickness(5);
            }
            //stack.Background = Brushes.Aquamarine;
            //stack.HorizontalAlignment = HorizontalAlignment.Center;
            //stack.Orientation = Orientation.Horizontal;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            stack.Margin = new Thickness(5);
            stack.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonClick));
        }

        private void ButtonClick(object sender, RoutedEventArgs e) {
            Button btn = e.Source as Button;
            Title = btn.Name;
            Random rand = new Random();
            var r = rand.Next(10);
            btn.FontSize += r;
            btn.Content = $"Button {btn.Name} says 'Click me' {r}";
            //MessageBox.Show($"Button {btn.Name} has been clicked");
        }
    }
}

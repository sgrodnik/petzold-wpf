using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ScrollFiftyButtons {
    internal class ScrollFiftyButtons : Window {
        [STAThread]
        public static void Main() { new Application().Run(new ScrollFiftyButtons()); }
        public ScrollFiftyButtons() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            SizeToContent = SizeToContent.Width;
            AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick));
            //ScrollViewer scroll = new ScrollViewer();
            //Content = scroll;
            StackPanel stack = new StackPanel();
            stack.Margin = new Thickness(5);
            //scroll.Content = stack;
            for (int i = 0; i < 44; i++) {
                Button btn = new Button();
                btn.Name = $"Button{i + 1}";
                btn.Content = btn.Name + "qwe qwe qwe qwe ";
                btn.Margin = new Thickness(5);
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                stack.Children.Add(btn);
            }
            //scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            //scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            Viewbox view = new Viewbox();
            Content = view;
            view.Child = stack;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e) {
            Button btn = e.Source as Button;
            if (btn != null) { MessageBox.Show(btn.Name); }
        }
    }
}

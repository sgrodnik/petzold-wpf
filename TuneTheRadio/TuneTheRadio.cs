using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.TuneTheRadio {
    internal class TuneTheRadio : Window {
        [STAThread]
        public static void Main() { new Application().Run(new TuneTheRadio()); }
        public TuneTheRadio() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            SizeToContent = SizeToContent.WidthAndHeight;

            GroupBox group = new GroupBox();
            group.Header = "WindowStyle";
            group.Margin = new Thickness(96);
            group.Padding = new Thickness(5);
            Content = group;
            group.Background = new SolidColorBrush(Colors.Thistle);

            StackPanel stack = new StackPanel();
            group.Content = stack;
            stack.Background = new SolidColorBrush(Colors.PapayaWhip);

            stack.Children.Add(CreateRadioButton(
                ".None", WindowStyle.None));
            stack.Children.Add(CreateRadioButton(
                ".SingleBorderWindow", WindowStyle.SingleBorderWindow));
            stack.Children.Add(CreateRadioButton(
                ".ThreeDBorderWindow", WindowStyle.ThreeDBorderWindow));
            stack.Children.Add(CreateRadioButton(
                ".ToolWindow", WindowStyle.ToolWindow));
            AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(RadioOnChecked));
        }

        private void RadioOnChecked(object sender, RoutedEventArgs e) {
            RadioButton radio = e.Source as RadioButton;
            WindowStyle = (WindowStyle)radio.Tag;
        }

        private UIElement CreateRadioButton(string text, WindowStyle style) {
            RadioButton radio = new RadioButton();
            radio.Content = text;
            radio.Tag = style;
            radio.Margin = new Thickness(5);
            radio.IsChecked = (style == WindowStyle);
            radio.Background = new SolidColorBrush(Colors.Aquamarine);
            return radio;
        }
    }
}

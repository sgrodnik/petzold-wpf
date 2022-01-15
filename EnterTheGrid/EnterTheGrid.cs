using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.EnterTheGrid
{
    internal class EnterTheGrid : Window
    {
        [STAThread]
        public static void Main() { new Application().Run(new EnterTheGrid()); }
        public EnterTheGrid()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            MinWidth = 300;
            SizeToContent = SizeToContent.WidthAndHeight;

            StackPanel stackPanel = new StackPanel();
            Content = stackPanel;

            Grid grid1 = new Grid();
            grid1.Margin = new Thickness(5);
            stackPanel.Children.Add(grid1);

            for (int i = 0; i < 5; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid1.RowDefinitions.Add(row);
            }
            
            ColumnDefinition column = new ColumnDefinition();
            column.Width = GridLength.Auto;
            grid1.ColumnDefinitions.Add(column);
            column = new ColumnDefinition();
            column.Width = new GridLength(100, GridUnitType.Star);
            grid1.ColumnDefinitions.Add(column);

            string[] strLabels = {"First name:", "Last name:",
                                  "SSN:", "Credit card number:",
                                  "Other:"};
            for (int i = 0; i < strLabels.Length; i++)
            {
                Label label = new Label();
                label.Content = strLabels[i];
                //label.VerticalAlignment = VerticalAlignment.Center;
                grid1.Children.Add(label);
                Grid.SetRow(label, i);
                Grid.SetColumn(label, 0);
                TextBox textBox = new TextBox();
                textBox.Margin = new Thickness(5);
                grid1.Children.Add(textBox);
                Grid.SetRow(textBox, i);
                Grid.SetColumn(textBox, 1);
            }

            Grid grid2 = new Grid();
            grid2.Margin = new Thickness(5);
            stackPanel.Children.Add(grid2);

            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());

            Button button = new Button();
            button.Content = "Submit";
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.IsDefault = true;
            button.Click += delegate { Close(); };
            grid2.Children.Add(button);

            button = new Button();
            button.Content = "Cancel";
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.IsDefault = true;
            button.Click += delegate { Close(); };
            grid2.Children.Add(button);
            Grid.SetColumn(button, 1);

            (stackPanel.Children[0] as Panel).Children[1].Focus();
        }
    }
}

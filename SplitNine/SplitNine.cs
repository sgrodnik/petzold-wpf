using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SplitNine
{
    internal class SplitNine : Window
    {
        [STAThread]
        public static void Main() { new Application().Run(new SplitNine()); }
        public SplitNine()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Grid grid = new Grid();
            Content = grid;

            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Button btn = new Button();
                    btn.Margin = new Thickness(25);
                    btn.Content = $"Row {y}, Col {x}";
                    grid.Children.Add(btn);
                    Grid.SetRow(btn, y);
                    Grid.SetColumn(btn, x);
                }
            }
            GridSplitter splitter = new GridSplitter();
            splitter.Width = 6;
            splitter.HorizontalAlignment = HorizontalAlignment.Left;
            splitter.ShowsPreview = true;
            grid.Children.Add(splitter);
            Grid.SetRow(splitter, 1);
            Grid.SetColumn(splitter, 1);
        }
    }
}

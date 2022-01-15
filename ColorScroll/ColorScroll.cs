using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ColorScroll
{
    internal class ColorScroll : Window
    {
        ScrollBar[] scrolls = new ScrollBar[3];
        TextBlock[] txtValue = new TextBlock[3];
        Panel pnlColor;

        [STAThread]
        public static void Main() { new Application().Run(new ColorScroll()); }
        public ColorScroll()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            Width = 500;
            Height = 300;

            Grid gridMain = new Grid();
            Content = gridMain;

            ColumnDefinition column = new ColumnDefinition();
            column.Width = new GridLength(200, GridUnitType.Pixel);
            gridMain.ColumnDefinitions.Add(column);

            column = new ColumnDefinition();
            column.Width = GridLength.Auto;
            gridMain.ColumnDefinitions.Add(column);

            column = new ColumnDefinition();
            column.Width = new GridLength(100, GridUnitType.Star);
            gridMain.ColumnDefinitions.Add(column);

            GridSplitter splitter = new GridSplitter();
            splitter.HorizontalAlignment = HorizontalAlignment.Center;
            splitter.VerticalAlignment = VerticalAlignment.Stretch;
            splitter.Width = 6;
            gridMain.Children.Add(splitter);
            Grid.SetRow(splitter, 0);
            Grid.SetColumn(splitter, 1);

            pnlColor = new StackPanel();
            pnlColor.Background = new SolidColorBrush(SystemColors.WindowColor);
            gridMain.Children.Add(pnlColor);
            Grid.SetRow(pnlColor, 0);
            Grid.SetColumn(pnlColor, 2);

            Grid grid = new Grid();
            gridMain.Children.Add(grid);
            Grid.SetRow(grid, 0);
            Grid.SetColumn(grid, 0);

            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowDef);

            rowDef = new RowDefinition();
            rowDef.Height = new GridLength(100, GridUnitType.Star);
            grid.RowDefinitions.Add(rowDef);

            rowDef = new RowDefinition();
            rowDef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowDef);

            for (int i = 0; i < 3; i++)
            {
                column = new ColumnDefinition();
                column.Width = new GridLength(33, GridUnitType.Star);
                grid.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i < 3; i++)
            {
                Label lbl = new Label();
                lbl.Content = new string[] { "Red", "Green", "Blue" }[i];
                lbl.HorizontalAlignment = HorizontalAlignment.Center;
                grid.Children.Add(lbl);
                Grid.SetRow(lbl, 0);
                Grid.SetColumn(lbl, i);

                scrolls[i] = new ScrollBar();
                scrolls[i].Focusable = true;
                scrolls[i].Orientation = Orientation.Vertical;
                scrolls[i].Minimum = 0;
                scrolls[i].Maximum = 255;
                scrolls[i].SmallChange = 1;
                scrolls[i].LargeChange = 16;
                scrolls[i].ValueChanged += ScrollOnValueChanged;
                grid.Children.Add(scrolls[i]);
                Grid.SetRow(scrolls[i], 1);
                Grid.SetColumn(scrolls[i], i);

                txtValue[i] = new TextBlock();
                txtValue[i].TextAlignment = TextAlignment.Center;
                txtValue[i].HorizontalAlignment = HorizontalAlignment.Center;
                txtValue[i].Margin = new Thickness(5);
                grid.Children.Add(txtValue[i]);
                Grid.SetRow(txtValue[i], 2);
                Grid.SetColumn(txtValue[i], i);
            }

            Color clr = (pnlColor.Background as SolidColorBrush).Color;
                scrolls[0].Value = clr.R;
                scrolls[1].Value = clr.G;
                scrolls[2].Value = clr.B;

                scrolls[0].Focus();
            void ScrollOnValueChanged(object sender, EventArgs e)
            {
                ScrollBar scroll = sender as ScrollBar;
                Panel pnl = scroll.Parent as Panel;
                TextBlock txt = pnl.Children[1 + pnl.Children.IndexOf(scroll)] as TextBlock;

                txt.Text = $"{(int)scroll.Value}\n0x{(int)scroll.Value}";
                pnlColor.Background = new SolidColorBrush(
                    Color.FromRgb((byte)scrolls[0].Value,
                                  (byte)scrolls[1].Value,
                                  (byte)scrolls[2].Value));
            }
        }
    }
}

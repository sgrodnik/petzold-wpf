using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SetSpaceProperty
{
    internal class SetSpaceProperty : SpaceWindow
    {
        [STAThread]
        public static void Main() { new Application().Run(new SetSpaceProperty()); }
        public SetSpaceProperty()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            int[] iSpaces = { 0, 1, 2 };

            // Create Grid panel.
            Grid grid = new Grid();
            Content = grid;

            // Define row and columns.
            for (int i = 0; i < 2; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i < iSpaces.Length; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }

            // Create six buttons.
            for (int i = 0; i < iSpaces.Length; i++)
            {
                SpaceButton btn = new SpaceButton();
                btn.Text = "Set window Space to " + iSpaces[i];
                btn.Tag = iSpaces[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += WindowPropertyOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 0);
                Grid.SetColumn(btn, i);

                btn = new SpaceButton();
                btn.Text = "Set button Space to " + iSpaces[i];
                btn.Tag = iSpaces[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += ButtonPropertyOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 1);
                Grid.SetColumn(btn, i);
            }
        }

        private void WindowPropertyOnClick(object sender, RoutedEventArgs e)
        {
            SpaceButton btn = e.Source as SpaceButton;
            Space = (int)btn.Tag;
        }

        private void ButtonPropertyOnClick(object sender, RoutedEventArgs e)
        {
            SpaceButton btn = e.Source as SpaceButton;
            btn.Space = (int)btn.Tag;
        }
    }
}

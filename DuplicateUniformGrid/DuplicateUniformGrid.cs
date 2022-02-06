//-----------------------------------------------------
// DuplicateUniformGrid.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DuplicateUniformGrid
{
    public class DuplicateUniformGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DuplicateUniformGrid());
        }
        public DuplicateUniformGrid()
        {
            Title = "Duplicate Uniform Grid";

            // Create UniformGridAlmost as content of window.
            UniformGridAlmost unigrid = new UniformGridAlmost();
            //SizeToContent = SizeToContent.WidthAndHeight;
            unigrid.Columns = 5;
            //unigrid.HorizontalAlignment = HorizontalAlignment.Center;
            //unigrid.VerticalAlignment = VerticalAlignment.Center;
            Content = unigrid;

            // Fill UniformGridAlmost with randomly-sized buttons.
            Random rand = new Random();

            for (int index = 0; index < 48; index++)
            {
                Button btn = new Button();
                btn.Name = "Button" + index;
                btn.Content = btn.Name;
                btn.FontSize += rand.Next(10);
                unigrid.Children.Add(btn);
                //btn.HorizontalAlignment = HorizontalAlignment.Center;
                //btn.VerticalAlignment = VerticalAlignment.Center;
            }
            AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick));
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Button btn = args.Source as Button;
            MessageBox.Show(btn.Name + " has been clicked", Title);
        }
    }
}

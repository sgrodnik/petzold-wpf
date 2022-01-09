using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ExploreDirectories {
    internal class ExploreDirectories : Window {
        [STAThread]
        public static void Main() { new Application().Run(new ExploreDirectories()); }
        public ExploreDirectories() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            ScrollViewer scroll = new ScrollViewer();
            Content = scroll;
            WrapPanel wrap = new WrapPanel();
            scroll.Content = wrap;
            wrap.Children.Add(new FileSystemInfoButton());
            //wrap.HorizontalAlignment = HorizontalAlignment.Center;
        }
    }
}

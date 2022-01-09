using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DockAroundTheBlock {
    internal class DockAroundTheBlock : Window {
        [STAThread]
        public static void Main() { new Application().Run(new DockAroundTheBlock()); }
        public DockAroundTheBlock() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            DockPanel dock = new DockPanel();
            Content = dock;
            //dock.LastChildFill = false;
            for (int i = 0; i < 37; i++) {
                Button btn = new Button();
                btn.Content = $"Button {i + 1}";
                dock.Children.Add(btn);
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
            }
        }
    }
}

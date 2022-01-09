using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.MeetTheDockers {
    internal class MeetTheDockers : Window {
        [STAThread]
        public static void Main() { new Application().Run(new MeetTheDockers()); }
        public MeetTheDockers() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            DockPanel dock = new DockPanel();
            Content = dock;

            Menu menu = new Menu();
            MenuItem item = new MenuItem();
            item.Header = "Menuuu";
            menu.Items.Add(item);

            DockPanel.SetDock(menu, Dock.Top);
            dock.Children.Add(menu);

            ToolBar toolBar = new ToolBar();
            toolBar.Header = "Toolbar";

            DockPanel.SetDock(toolBar, Dock.Top);
            dock.Children.Add(toolBar);

            StatusBar statusBar = new StatusBar();
            StatusBarItem statusBarItem = new StatusBarItem();
            statusBarItem.Content = "Status";
            statusBar.Items.Add(statusBarItem);

            DockPanel.SetDock(statusBar, Dock.Bottom);
            dock.Children.Add(statusBar);

            ListBox listBox = new ListBox();
            listBox.Items.Add("List box item");

            DockPanel.SetDock(listBox, Dock.Left);
            dock.Children.Add(listBox);

            TextBox textBox = new TextBox();
            textBox.AcceptsReturn = true;

            dock.Children.Add(textBox);
            textBox.Focus();
        }
    }
}

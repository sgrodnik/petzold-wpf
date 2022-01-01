using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.HandleAnEvent
{
    class HandleAnEvent
    {
        [STAThread]
        public static void Main()
        {
            var app = new Application();
            var win = new Window();
            win.Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            win.MouseDown += WindowOnMouseDown;
            app.Run(win);
        }

        static void WindowOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var win = sender as Window;
            var message = $"{e.ChangedButton}---{e.GetPosition(win)}";
            //MessageBox.Show(message, win.Title);
            win.Title = message;
        }
    }
}
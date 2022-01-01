using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritTheApp
{
    class InheritTheApp : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new InheritTheApp();
            app.Run();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var win = new Window();
            win.Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            win.Show();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            MessageBoxResult res = MessageBox.Show(
                "Exit?",
                "Title111111111111",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes
            );
            //e.Cancel = (res == MessageBoxResult.Cancel);
            //e;
        }
    }
}
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.ThrowWindowParty
{
    internal class ThrowWindowParty : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new ThrowWindowParty();
            //app.ShutdownMode = ShutdownMode.OnMainWindowClose;
            app.Run();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWin = new Window();
            mainWin.Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            mainWin.MouseDown += WindowsOnMouseDown;
            mainWin.Show();

            for (int i = 0; i < 2; i++)
            {
                var win = new Window();
                win.Title = $"win {i + 1}";
                win.ShowInTaskbar = false;
                win.Owner = mainWin;
                win.Show();

            }
        }

        private void WindowsOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var win = new Window();
            win.ShowDialog();
        }
    }
}
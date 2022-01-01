using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.Class
{
    internal class ThrowWindowParty : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new ThrowWindowParty();
            app.Run();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var win = new Window();
            win.Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            win.Show();
        }
    }
}
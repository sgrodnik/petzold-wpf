using System.Windows;

namespace Petzold.InheritAppAndWindow
{
    internal class MyApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var win = new MyWindow();
            win.Show();
        }
    }
}
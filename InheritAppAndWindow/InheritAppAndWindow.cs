using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritAppAndWindow
{
    internal class InheritAppAndWindow
    {
        [STAThread]
        public static void Main()
        {
            var app = new MyApplication();
            app.Run();
        }
    }
}
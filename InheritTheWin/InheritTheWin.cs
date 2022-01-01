using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritTheWin
{
    internal class InheritTheWin : Window
    {
        [STAThread]
        public static void Main()
        {
            new Application().Run(new InheritTheWin());
        }
        public InheritTheWin()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
        }
    }
}
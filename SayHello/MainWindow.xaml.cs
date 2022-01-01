using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Petzold.SayHello
{
    class SayHello
    {
        [STAThread]
        public static void Main()
        {
            var win = new Window();
            win.Title = "Say h";
            //win.Show();

            var app = new Application();
            app.Run(win);
        }
    }
}

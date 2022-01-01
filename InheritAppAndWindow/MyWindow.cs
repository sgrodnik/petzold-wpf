using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritAppAndWindow
{
    internal class MyWindow : Window
    {
        public MyWindow()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            Title = $"{e.ChangedButton}-{e.GetPosition(this)}";
        }
    }
}
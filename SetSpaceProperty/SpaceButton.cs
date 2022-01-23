using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SetSpaceProperty
{
    internal class SpaceButton : Button
    {
        private string txt;

        public string Text
        {
            get { return txt; }
            set
            {
                txt = value;
                Content = SpaceOutText(txt);
            }
        }

        public static readonly DependencyProperty SpaceProperty;

        public int Space
        {
            get { return (int)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        //// Using a DependencyProperty as the backing store for Space.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SpaceProperty =
        //    DependencyProperty.Register("Space", typeof(int), typeof(ownerclass), new PropertyMetadata(0));

        static SpaceButton()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.DefaultValue = 1;
            metadata.AffectsMeasure = true;
            metadata.Inherits = true;
            metadata.PropertyChangedCallback += OnSpacePropertyChanged;

            SpaceProperty = DependencyProperty.Register("Space", typeof(int), typeof(SpaceButton),
                                                        metadata, ValidateSpaceValue);
        }

        static bool ValidateSpaceValue(object obj)
        {
            int i = (int)obj;
            return i >= 0;
        }

        private static void OnSpacePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SpaceButton button = (SpaceButton)d;
            button.Content = button.SpaceOutText(button.Text);
        }

        private object SpaceOutText(string text)
        {
            if (text == null)
                return null;

            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
                sb.Append(c + new string(' ', Space));

            return sb.ToString();
        }
    }
}

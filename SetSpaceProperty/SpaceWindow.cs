using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SetSpaceProperty
{
    internal class SpaceWindow : Window
    {
        public static readonly DependencyProperty SpaceProperty;
        public int Space
        {
            get { return (int)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        static SpaceWindow()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.Inherits = true;
            SpaceProperty = SpaceButton.SpaceProperty.AddOwner(typeof(SpaceWindow));
            SpaceProperty.OverrideMetadata(typeof(SpaceWindow), metadata);
        }
    }
}

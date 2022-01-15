using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.CalculateYourLife
{
    internal class CalculateYourLife : Window
    {
        TextBox textBoxBegin, textBoxEnd;
        Label labelLifeYear;

        [STAThread]
        public static void Main() { new Application().Run(new CalculateYourLife()); }
        public CalculateYourLife()
        {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;

            Grid grid = new Grid();
            Content = grid;
            for (int i = 0; i < 3; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i < 2; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(column);
            }
            Label label = new Label();
            label.Content = "Begin Date";
            grid.Children.Add(label);
            Grid.SetRow(label, 0);
            Grid.SetColumn(label, 0);

            textBoxBegin = new TextBox();
            textBoxBegin.Text = new DateTime(1980, 1, 1).ToShortDateString();
            textBoxBegin.TextChanged += TextBoxOnTextChanged;
            grid.Children.Add(textBoxBegin);
            Grid.SetRow(textBoxBegin, 0);
            Grid.SetColumn(textBoxBegin, 1);

            label = new Label();
            label.Content = "End Date";
            grid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 0);

            textBoxEnd = new TextBox();
            textBoxEnd.TextChanged += TextBoxOnTextChanged;
            grid.Children.Add(textBoxEnd);
            Grid.SetRow(textBoxEnd, 1);
            Grid.SetColumn(textBoxEnd, 1);

            label = new Label();
            label.Content = "Live Years";
            grid.Children.Add(label);
            Grid.SetRow(label, 2);
            Grid.SetColumn(label, 0);

            labelLifeYear = new Label();
            grid.Children.Add(labelLifeYear);
            Grid.SetRow(labelLifeYear, 2);
            Grid.SetColumn(labelLifeYear, 1);

            Thickness thickness = new Thickness(5);
            grid.Margin = thickness;
            foreach (Control control in grid.Children)
            {
                control.Margin = thickness;
            }

            textBoxBegin.Focus();
            textBoxEnd.Text = DateTime.Now.ToShortDateString();
        }

        private void TextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime dtBeg, dtEnd;
            if (DateTime.TryParse(textBoxBegin.Text, out dtBeg) &&
                DateTime.TryParse(textBoxEnd.Text, out dtEnd))
            {
                int iYears = dtEnd.Year - dtBeg.Year;
                int iMonths = dtEnd.Month - dtBeg.Month;
                int iDays = dtEnd.Day - dtBeg.Day;
                if (iDays < 0)
                {
                    iDays += DateTime.DaysInMonth(dtEnd.Year,
                                                  1 + (dtEnd.Month + 10) % 12);
                    iMonths -= 1;
                }
                if (iMonths < 0)
                {
                    iMonths += 12;
                    iYears -= 1;
                }
                labelLifeYear.Content = $"{iYears} y, {iMonths} m, {iDays} d";
            }
            else
            {
                labelLifeYear.Content += " -";
            }
        }
    }
}

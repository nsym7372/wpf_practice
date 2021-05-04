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

namespace WpfPractice2
{
    /// <summary>
    /// DateSample.xaml の相互作用ロジック
    /// </summary>
    public partial class DateSample : Page
    {
        public DateSample()
        {
            InitializeComponent();

            cal.BlackoutDates.AddDatesInPast();
            cal.BlackoutDates.Add(new CalendarDateRange(DateTime.Today.AddDays(1), DateTime.Today.AddDays(3)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = string.Join(Environment.NewLine, cal.SelectedDates.Select(r => r.ToShortDateString()));
            MessageBox.Show(selected);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = sender as DatePicker;
            MessageBox.Show(s.ToString());
        }
    }
}

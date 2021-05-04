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
using System.Windows.Shapes;

namespace WpfPractice
{
    /// <summary>
    /// EventSample.xaml の相互作用ロジック
    /// </summary>
    public partial class EventSample : Window
    {
        public EventSample()
        {
            InitializeComponent();
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content += GetString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "";
        }

        private void AAAButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content += GetString(3);
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content += GetString();
        }

        private void ExceptionButton_Click(object sender, RoutedEventArgs e)
        {
            throw new InvalidOperationException("てすと");
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            TxInputString.Text = GetString();
        }

        private string GetString(int times = 1)
        {
            var ret = "";
            foreach (var i in Enumerable.Range(0, times))
            {
                ret += ((bool)BtToggle.IsChecked) ? "A" : "B"; ;
            }
            return ret;

           
        }
    }
}

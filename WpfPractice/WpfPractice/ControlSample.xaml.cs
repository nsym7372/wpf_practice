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
    /// ControlSample.xaml の相互作用ロジック
    /// </summary>
    public partial class ControlSample : Window
    {
        public ControlSample()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ASlider.Text = e.NewValue.ToString();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TxProgress.Text = Progress.Value.ToString() + "%";
        }

        private void BtProgress_Click(object sender, RoutedEventArgs e)
        {
            //Progress.IsIndeterminate = true;
            //TxProgress.Text = "処理中・・・";

            Task.Run(() =>
            {
                foreach (var i in Enumerable.Range(0, 10))
                {
                    System.Threading.Thread.Sleep(500);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Progress.Value += 10;
                    });
                }
            });
        }

        private void BtCombo_Click(object sender, RoutedEventArgs e)
        {
            var person = CbPerson.SelectedItem as Models.Person;
            MessageBox.Show(person.Phone);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using var db = new Models.WPFContext();
            var people = db.People.ToList();

            var Company = new Section()
            {
                Name = "xxx 株式会社",
                Sections = new List<Section>()
                {
                    new Section(){Name = "営業部"},
                    new Section(){Name = "財務部"}
                }
            };

            DataContext = new { People = people, Company = Company };
        }


        private class Section
        {
            public string Name { get; set; }
            public List<Section> Sections { get; set; }
        }
    }
}

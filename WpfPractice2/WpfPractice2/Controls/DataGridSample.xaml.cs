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
    using ConsoleApp1;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// DataGridSample.xaml の相互作用ロジック
    /// </summary>
    public partial class DataGridSample : Page
    {
        public DataGridSample()
        {
            InitializeComponent();

            var data = new ObservableCollection<ConsoleApp1.Person>(

                Enumerable.Range(1, 100).Select(r => new ConsoleApp1.Person
                {
                    FullName = $"しめい {r}",
                    Gender = (r % 2 == 0) ? Gender.Men : Gender.Women,
                    Age = 20 + r % 50,
                    AuthMember = (r % 5 == 0)
                }

                )) ;

            this.SampleGrid.ItemsSource = data;
            this.SampleGrid2.ItemsSource = data;
            this.SampleGrid3.ItemsSource = data;
        }

        private void SampleGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "FullName":
                    e.Column.Header = "名前";
                    e.Column.DisplayIndex = 0;
                    break;

                case "Age":
                    e.Column.Header = "年齢";
                    e.Column.DisplayIndex = 1;
                    break;

                case "Gender":
                    e.Column.Header = "性別";
                    e.Column.DisplayIndex = 2;
                    break;

                case "AuthMember":
                    e.Column.Header = "承認済み";
                    e.Column.DisplayIndex = 3;
                    break;

                default:
                    e.Cancel = true;
                    break;
            }
        }
    }

    public class GenderComboBoxItem
    {
        public string Label { get; set; }
        public Gender Value { get; set; }
    }
}

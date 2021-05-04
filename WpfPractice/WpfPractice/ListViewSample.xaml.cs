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
    using System.Linq;
    using Models;
    using System.Collections.ObjectModel;
    /// <summary>
    /// ListViewSample.xaml の相互作用ロジック
    /// </summary>
    public partial class ListViewSample : Window
    {
        //private ObservableCollection<Person> customers;

        public ListViewSample()
        {
            InitializeComponent();

        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            using var db = new WPFContext();
            db.People.Add(new Person()
            {
                Name = "name",
                Phone = "123-4567"
            });
            db.SaveChanges();

            DrawGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGrid();
        }

        private void DrawGrid()
        {
            using var db = new WPFContext();
            var customers = db.People.Where(r => r.Phone.Contains(TxSearch.Text)).ToList();

            CustomerListView.ItemsSource = new ObservableCollection<Person>(customers);
        }

        private void TxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DrawGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var next = new EventSample();
            this.Hide();
            next.ShowDialog();
            this.Show();
        }
    }
}

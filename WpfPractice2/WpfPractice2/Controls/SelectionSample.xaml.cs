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
    /// SelectionSample.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectionSample : Page
    {
        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public SelectionSample()
        {
            InitializeComponent();

            var source = Enumerable.Range(1, 10)
                .Select(r => new Person { Name = $"名前{r}", Age = 20 + r }).ToList();

            combo.ItemsSource = source;
            combo_SelectionChanged(combo, null);

            list.ItemsSource = source;
        }

        private void ShowMessage(string msg)
        {
            text.Text = msg;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ShowMessage("オン");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowMessage("オフ");
        }

        private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            ShowMessage("その他");
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = sender as ComboBox;

            selected_index.Text = c.SelectedIndex.ToString();
            selected_item.Text = c.SelectedItem?.ToString();
            selected_text.Text = c.Text;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

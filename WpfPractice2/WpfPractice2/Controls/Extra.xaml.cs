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
    using Microsoft.Win32;
    /// <summary>
    /// Extra.xaml の相互作用ロジック
    /// </summary>
    public partial class Extra : Page
    {
        public Extra()
        {
            InitializeComponent();

            tabs.ItemsSource = Enumerable.Range(1, 10).Select(r => new { Name = $"名前{r}", Age = 20 + r }).ToList();
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.ShowDialog();

        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
        }
    }
}

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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Controller_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new ControlSample());
        }

        private void CRUD_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new CRUDSample());
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new EventSample());
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new GridSample());
        }

        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new ListViewSample());
        }

        private void Resource_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new ResoruceSample());
        }

        private void Selector_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new SelectorSample());
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new StackpanelSample());
        }

        private void OpenWindow(Window w)
        {
            this.Hide();
            w.ShowDialog();
            this.Show();
        }

        private void Binding_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(new BindingSample());
        }
    }
}

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

namespace WpfPractice2.PropertyChange
{
    /// <summary>
    /// PropertyChangeSample.xaml の相互作用ロジック
    /// </summary>
    public partial class PropertyChangeSample : Page
    {
        PropertyChangeViewModel _vm = new PropertyChangeViewModel();
        public PropertyChangeSample()
        {
            InitializeComponent();

            _vm.PropertyChanged += (_, e) => MessageBox.Show($"{e.PropertyName} changed");

            _vm.Message = "Hello World";
            _vm.Message = "Hello World2";

            this.DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_vm.Message);
        }
    }
}

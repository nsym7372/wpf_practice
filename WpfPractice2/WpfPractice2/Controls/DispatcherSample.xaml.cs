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
    using System.Windows.Threading;
    using System.Diagnostics;
    /// <summary>
    /// DispatcherSample.xaml の相互作用ロジック
    /// </summary>
    public partial class DispatcherSample : Page
    {
        public DispatcherSample()
        {
            InitializeComponent();

            var d = new DerivedObject();
            d.DoSomething();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new DerivedObject();
            d.DoSomething();
        }

        private async void NGButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new DerivedObject();
            try
            {
                await Task.Run(() => d.DoSomething());
            }
            catch
            {
                MessageBox.Show("例外");
            }
        }

        private async void DispatcherButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new DerivedObject();
            await Task.Run(async () => 
            {
                if (d.CheckAccess() == false)
                {
                    await d.Dispatcher.InvokeAsync(() => d.DoSomething());
                }
            });
        }
    }

    public class DerivedObject : DispatcherObject
    {
        public void DoSomething()
        {
            this.VerifyAccess();
            MessageBox.Show("Hello");
        }
    }
}

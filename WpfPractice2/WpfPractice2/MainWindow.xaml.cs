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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var anthem = new Animal()
            {
                Name = "あんせむ",
                Age = 9,
                Picture = new BitmapImage(new Uri("./face.png", UriKind.Relative))
            };

            button3.Content = anthem;

        }

        public class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public BitmapImage Picture { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var w = new StyleSample();
            w.Show();
        }
    }
}

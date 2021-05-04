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
    /// BindingSample.xaml の相互作用ロジック
    /// </summary>
    public partial class BindingSample : Window
    {
        public int X { get; set; }
        public int Y { get; set; }


        public BindingSample()
        {
            InitializeComponent();

            X = 10;
            Y = 20;


            DataContext = this;
        }

        //https://www.atmarkit.co.jp/ait/articles/1010/08/news123.html

        public class Manager
        {
            public string FamilyName { get; set; }
        }

        public class Contents
        {
            public string URL { get; set; }
        }
    }
}

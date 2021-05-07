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
    /// TreeViewSample.xaml の相互作用ロジック
    /// </summary>
    public partial class TreeViewSample : Page
    {
        public TreeViewSample()
        {
            InitializeComponent();

            tree.ItemsSource = new List<Person>
            {
                new Person()
                {
                    FullName = "田中一郎",
                    Children = new ItemCollection()
                    {
                        new Person(){FullName = "田中二郎"},
                        new Person(){FullName = "田中三郎"},
                        new Person()
                        {
                            FullName = "田中四郎",
                            Children = new ItemCollection()
                            {
                                new Person{FullName = "木村はな"},
                                new Person{FullName = "木村うめ"}
                            }
                        }
                    }
                },
                new Person
                {
                    FullName = "鈴木四郎",
                    Children = new ItemCollection
                    {
                        new Person {FullName = "鈴木五郎"}
                    }
                }
            };
        }
    }
}

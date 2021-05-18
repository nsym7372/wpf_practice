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

namespace WpfPractice2.Bindings
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// CollectionBIndingSample.xaml の相互作用ロジック
    /// </summary>
    public partial class CollectionBIndingSample : Page
    {
        private ObservableCollection<CollectionBindingPerson> people_;
        public CollectionBIndingSample()
        {
            InitializeComponent();
            people_ = new ObservableCollection<CollectionBindingPerson>(
                Enumerable.Range(0, 100).Select(r => new CollectionBindingPerson
                {
                    Name = $"名前 {r}",
                    Age = (20 + (r % 20))
                }));

            DataContext = people_;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            people_.Insert(0, new CollectionBindingPerson()
            {
                Name = "追加氏名",
                Age = DateTime.Now.Millisecond % 100
            }) ;
        }

        private void menuClear_Click(object sender, RoutedEventArgs e)
        {
            this.people_.Clear();
        }

        private void menuFilterAdd_Click(object sender, RoutedEventArgs e)
        {
            var cv = CollectionViewSource.GetDefaultView(people_);
            cv.Filter = x =>
            {
                var person = (CollectionBindingPerson)x;
                return person.Age % 2 == 0;
            };
        }

        private void menuSort_Click(object sender, RoutedEventArgs e)
        {
            var cv = CollectionViewSource.GetDefaultView(people_);
            cv.SortDescriptions.Add(new System.ComponentModel.SortDescription("Age", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void menuSortRemove_Click(object sender, RoutedEventArgs e)
        {
            var cv = CollectionViewSource.GetDefaultView(people_);
            cv.SortDescriptions.Clear();
        }

        private void menuFilterClear_Click(object sender, RoutedEventArgs e)
        {
            var cv = CollectionViewSource.GetDefaultView(people_);
            cv.Filter = x => { return true; };
        }
    }

    public class CollectionBindingPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

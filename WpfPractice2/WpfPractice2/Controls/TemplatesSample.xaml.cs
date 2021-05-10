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

namespace WpfPractice2.Controls
{
    /// <summary>
    /// TemplatesSample.xaml の相互作用ロジック
    /// </summary>
    public partial class TemplatesSample : Page
    {
        public TemplatesSample()
        {
            InitializeComponent();

            var source = Enumerable.Range(0, 10).Select(r => new ControlsPerson()
            {
                Name = $"なまえ {r}",
                Age = 20 + r
            });

            listbox.ItemsSource = source;

            listbox1.ItemsSource = source;

            listbox2.ItemsSource = source;
            

        }
    }
    public class ControlsPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsOver25 { get { return Age >= 25; } }
    }

    public class PersonDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var p = (ControlsPerson)item;
            var key = (p.Age % 2 == 0) ? "PersonTemplate" : "PersonTemplate1";
            return (DataTemplate)((FrameworkElement)container).FindResource(key);

        }

    }




}

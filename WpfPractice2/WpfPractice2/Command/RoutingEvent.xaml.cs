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

namespace WpfPractice2.Command
{
    /// <summary>
    /// RoutingEvent.xaml の相互作用ロジック
    /// </summary>
    public partial class RoutingEvent : Page
    {
        public RoutingEvent()
        {
            InitializeComponent();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            var parent = new Person { Name = "parent" };
            var child = new Person { Name = "child" };

            parent.AddChild(child);

            // parentだけ、イベントを追加
            parent.ToAge += (object s, RoutedEventArgs e) =>
            {
                var message = $"sender : {((Person)s).Name} / name : {((Person)e.Source).Name}";
                MessageBox.Show(message);
            };

            // parent にはイベントを登録した
            parent.RaiseEvent(new RoutedEventArgs(Person.ToAgeEvent));
            
            // child　にはイベントを（明示的に）登録していない ＝　トンネルイベントとして登録された
            child.RaiseEvent(new RoutedEventArgs(Person.ToAgeEvent));
        }
    }

    class Person : FrameworkElement
    {
        public static RoutedEvent ToAgeEvent = EventManager.RegisterRoutedEvent(
            "ToAge",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(Person)
            );

        public event RoutedEventHandler ToAge
        {
            add { this.AddHandler(ToAgeEvent, value); }
            remove { this.RemoveHandler(ToAgeEvent, value); }
        }

        public void AddChild(Person child)
        {
            this.AddLogicalChild(child);
        }
    }
}

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
    /// Properties.xaml の相互作用ロジック
    /// </summary>
    public partial class DependencyPropertySample : Page
    {
        public DependencyPropertySample()
        {
            InitializeComponent();
        }

        private void ShowName(Person p)
        {
            MessageBox.Show(p.GetValue(Person.NameProperty).ToString());
        }

        private void Single_Click(object sender, RoutedEventArgs e)
        {

            var p = new Person();
            ShowName(p);

            p.SetValue(Person.NameProperty, "てすと１");
            ShowName(p);

            p.Name = "テスト２";
            MessageBox.Show(p.Name);
        }

        private void Object_Click(object sender, RoutedEventArgs e)
        {
            var p1 = new Person();
            var p2 = new Person();

            p1.Children.Add(new Person());
            p2.Children.Add(new Person());

            MessageBox.Show($"p1.children = {p1.Children.Count}{Environment.NewLine}p2.children = {p2.Children.Count}");
        }

        private void Changed_Click(object sender, RoutedEventArgs e)
        {
            var p = new Person();
            p.Name2 = "new value";
        }

        private void Coerce_Click(object sender, RoutedEventArgs e)
        {
            var p = new Person();
            p.Name2 = TxCoerce.Text;
            MessageBox.Show($"{p.Name2}");
        }

    }

    public class Person : DependencyObject
    {
        public Person()
        {
            //ChildrenPropertyの初期値を共有しない場合に必要
            //this.Children = new List<Person>(); 
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(
                "Name", //プロパティ名
                typeof(string), //プロパティ型
                typeof(Person), //設定する対象
                new PropertyMetadata("defalut name")    //初期値
                );

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }



        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register(
                "Children",
                typeof(List<Person>),
                typeof(Person),
                new PropertyMetadata(new List<Person>())    //デフォルト値は共有される
                );
        
        public List<Person> Children
        {
            get { return (List<Person>)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public static readonly DependencyProperty NameProperty2 =
            DependencyProperty.Register(
                "Name2",
                typeof(string),
                typeof(Person),
                new PropertyMetadata("default name", PropertyChanged, CoerceAgeValue),
                ValidateAgeValue
                );

        public string Name2
        {
            get { return (string)GetValue(NameProperty2); }
            set { SetValue(NameProperty2, value); }
        }

        // callback

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("プロパティ変更");
        }

        private static object CoerceAgeValue(DependencyObject d, object baseValue)
        {
            var value = ((string)baseValue).Length;
            if (value <= 1)
            {
                return "Blank";
            }
            if (value > 10)
            {
                return "Over";
            }
            return baseValue;
        }

        private static bool ValidateAgeValue(object value)
        {
            // MinValueとMaxValueはやりすぎだろ
            int lehgth = ((string)value).Length;
            return lehgth != 0; //falseで例外
        }
    }
}

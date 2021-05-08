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

namespace WpfPractice2.Property
{
    /// <summary>
    /// AttachedPropertySample.xaml の相互作用ロジック
    /// </summary>
    public partial class AttachedPropertySample : Page
    {
        public AttachedPropertySample()
        {
            InitializeComponent();

            // Sampleクラスから、Personの添付プロパティにvalueを設定
            // ex) コントロールから、GridのRowプロパティを設定するなど
            var p = new Person();
            Sample.SetBirthday(p, DateTime.Now);
            Console.WriteLine(Sample.GetBirthday(p));
        }
    }

    public class Sample : DependencyObject
    {
        public static readonly DependencyProperty BirthdayProperty =
            DependencyProperty.Register(    //依存プロパティとの違いは呼び出しメソッドだけ(Register or RegisterAttached)
                "Birthday",
                typeof(DateTime),
                typeof(Sample),
                new PropertyMetadata(DateTime.MinValue));

        // プログラムからアクセスする為
        public static DateTime GetBirthday(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(BirthdayProperty);
        }

        public static void SetBirthday(DependencyObject obj, DateTime value)
        {
            obj.SetValue(BirthdayProperty, value);
        }

    }
}

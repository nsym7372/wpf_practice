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
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// BindingSample.xaml の相互作用ロジック
    /// </summary>
    public partial class BindingSample : Page
    {
        public BindingSample()
        {
            InitializeComponent();


            this.DataContext = new BindingPerson()
            {
                Name = "坂本龍馬",
                Age = 30
            };
        }
        
        
    }

    public class BindingPerson : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
       

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                SetProperty(ref this.age, value);
                errors["Age"] = (value <= 0) ? new[] { "年齢は0以上" } : null;
                OnErrorChanged();
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref this.name, value);
                errors["Name"] = (value.Trim() == "") ? new[] { "名前を入力してください" } : null;
                OnErrorChanged();
            }
        }

        /// <summary>
        /// INotifyDataErrorInfo
        /// </summary>
        private Dictionary<string, IEnumerable> errors = new Dictionary<string, IEnumerable>(); //エラーあればメッセージを格納

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void OnErrorChanged([CallerMemberName] string propName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propName));
        }

        public bool HasErrors => errors.Values.Any(r => r != null);

        public IEnumerable GetErrors(string propertyName)
        {
            errors.TryGetValue(propertyName, out IEnumerable error);
            return error;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPractice2.Command
{
    using System.Windows.Input;
    using System.Windows;
    class DelegateCommandViewModel : PropertyChange.BindableBase
    {
        public DelegateCommand UpdateNowCommand { get; set; }

        private int _clicked;
        public int Clicked
        {
            get { return _clicked; }
            set { SetProperty(ref _clicked, value); }
        }



        public DelegateCommandViewModel()
        {
            Clicked = 0;
            this.UpdateNowCommand = new DelegateCommand(() =>
            {
                Clicked += 1;
            }, () => true);
        }

    }
}

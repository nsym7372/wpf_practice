using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPractice2.PropertySample
{
    using System.ComponentModel;
    class PropertyChangeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if(_Message == value)
                {
                    return;
                }

                _Message = value;
                RaisePropertyChanged(nameof(Message));
                
            }
        }
        
        protected void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

}

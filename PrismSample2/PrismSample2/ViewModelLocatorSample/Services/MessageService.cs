using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModelLocatorSample.Services
{
    public class MessageService : IMessageService
    {
        public MessageBoxResult Question(string message)
        {
            return MessageBox.Show(message, "確認", MessageBoxButton.OKCancel);
        }

        public void ShowDialog(string message)
        {
            MessageBox.Show(message);
        }
    }
}

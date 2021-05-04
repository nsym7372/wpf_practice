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
using System.Windows.Shapes;

namespace WpfPractice
{
    using Models;
    /// <summary>
    /// CRUDSample.xaml の相互作用ロジック
    /// </summary>
    public partial class CRUDSample : Window
    {
        public CRUDSample()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //create
            using var db = new WPFContext();
            db.People.Add(new Person()
            {
                Name = TxName.Text.Trim()
            });

            db.SaveChanges();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using var db = new WPFContext();

            if (int.TryParse(TxId.Text, out int id) == false)
            {
                return;
            }
            var person = db.People.Find(id);

            person.Name = TxName.Text;

            db.SaveChanges();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var idstr = (sender as TextBox).Text.Trim();

            if (int.TryParse(idstr, out int id) == false)
            {
                return;
            }

            var db = new WPFContext();
            if (db.People.Any(r => r.Id == id) == false)
            {
                return;
            }

            TxName.Text = db.People.Find(id).Name;
        }
    }
}

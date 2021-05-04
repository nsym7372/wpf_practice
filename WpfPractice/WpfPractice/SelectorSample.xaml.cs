﻿using System;
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
    /// <summary>
    /// SelectorSample.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectorSample : Window
    {
        public SelectorSample()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TxStatus.Text = "CheckBox_Checked";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TxStatus.Text = "CheckBox_Unchecked";
        }

        private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            TxStatus.Text = "CheckBox_Indeterminate";
        }
    }
}

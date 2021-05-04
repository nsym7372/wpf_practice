using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // 例外が処理されなかったら発生する（.NET 1.0より）
            AppDomain.CurrentDomain.UnhandledException
              += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(
                        object sender,
                        UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                MessageBox.Show("System.Exceptionとして扱えない例外");
                return;
            }

            string stacktrace = exception.StackTrace;
            string errorMember = exception.TargetSite.Name;
            string errorMessage = exception.Message;
            string message = string.Format(
        @"例外が{0}で発生。プログラムは終了します。
エラーメッセージ：{1}
stacktrace : {2}",
                                        errorMember, errorMessage, stacktrace);
            MessageBox.Show(message, "UnhandledException",
                            MessageBoxButton.OK, MessageBoxImage.Stop);
            Environment.Exit(0);
        }
    }
}

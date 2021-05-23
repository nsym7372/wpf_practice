using System;
using System.Collections.Generic;
using System.Text;

namespace PrismPractice2.Models
{
    using Prism.Mvvm;
    public class AppContext : BindableBase
    {
        private string message;
        public string Message
        {
            get { return this.message; }
            set { this.SetProperty(ref this.message, value); }
        }

        public Calc Calc { get; private set; }

        public AppContext()
        {
            this.Calc = new Calc(this);
        }
    }
}

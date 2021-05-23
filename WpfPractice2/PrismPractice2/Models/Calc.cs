using System;
using System.Collections.Generic;
using System.Text;

namespace PrismPractice2.Models
{
    using Prism.Mvvm;
    public class Calc : BindableBase
    {
        private AppContext appContext;
        public Calc(AppContext appContext)
        {
            this.appContext = appContext;
        }

        private double lhs;
        public double Lhs
        {
            get { return this.lhs; }
            set { SetProperty(ref lhs, value); }
        }

        private double rhs;
        public double Rhs
        {
            get { return this.rhs; }
            set { SetProperty(ref rhs, value); }
        }

        private OperatorType operatorType;
        public OperatorType OperatorType
        {
            get { return this.operatorType; }
            set { SetProperty(ref this.operatorType, value); }
        }

        private double answer;
        public double Answer
        {
            get { return this.answer; }
            set { SetProperty(ref this.answer, value); }
        }

        public void Execute()
        {
            switch (this.operatorType)
            {
                case OperatorType.Add:
                    this.Answer = this.Lhs + this.Rhs;
                    break;

                case OperatorType.Sub:
                    this.Answer = this.Lhs - this.Rhs;
                    break;

                case OperatorType.Div:
                    if(this.Rhs == 0)
                    {
                        this.appContext.Message = "0除算エラー";
                        return;
                    }
                    this.Answer = this.Lhs / this.Rhs;
                    break;

                case OperatorType.Mul:
                    this.Answer = this.Lhs * this.Rhs;
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public enum OperatorType
    {
        Add,
        Sub,
        Mul,
        Div
    }
}

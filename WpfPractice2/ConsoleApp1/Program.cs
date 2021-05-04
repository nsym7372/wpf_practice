using System;

namespace ConsoleApp1
{
    using System.Windows.Markup;

    class Program
    {
        static void Main(string[] args)
        {
            var s = typeof(Program).Assembly.GetManifestResourceStream("ConsoleApp1.Person.xaml");
            var p = XamlReader.Load(s) as Person;

            Console.WriteLine($"birthday:{p.Birthday}, name:{p.FullName}, salary:{p.Salary}" );

            foreach(var child in p.Children)
            {
                Console.WriteLine($"    {child.Id}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.ObjectModel;

    public enum Gender
    {
        None,
        Men,
        Women
    }

    public class Person
    {
        public Person()
        {
            this.Birthday = DateTime.Now;
        }

        public string Id { get; set; }
        public DateTime Birthday { get; private set; }
        public string FullName { get; set; }
        public int Salary { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public bool AuthMember { get; set; }
        public ItemCollection Children { get; set; }
    }


    public class ItemCollection : Collection<Person> { }
}

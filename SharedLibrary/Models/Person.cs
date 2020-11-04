using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Person
    {
        public Guid Id { get; private set; }
        public String FirstName { get; private set; }
        public String LastName { get; private set; }
        public int Age { get; private set; }
        public string FullName => $"{FirstName} + {LastName}";

        public Person(string firstname, string lastname, int age)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            Age = age;
        }

        public Person()
        {

        }
    }

    public class PersonViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }

        public PersonViewModel()
        {
            Persons = new ObservableCollection<Person>();

        }
    }
}

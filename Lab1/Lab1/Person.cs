using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Person
    {
        private string name;
        private string surname;
        private System.DateTime birthday;

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public Person()
        {
            this.name = "";
            this.surname = "";
            this.birthday = new DateTime(1997,12,24);
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public string Surname {
            get => surname;
            set => surname = value;
        }

        public DateTime Birthday {
            get => birthday;
            set => birthday = value;
        }

        public int ChangeYear {
            get { return this.birthday.Year; }
            set { this.birthday = new DateTime(value, birthday.Month, birthday.Day); }
        }

        public override string ToString()
        {
            return "Name: " + name + "; Surname: " + surname + "; Birthday: " + birthday.ToString() + ";";
        }

        public virtual string ToShortString() {
            return "Name: " + name + "; Surname: " + surname + ";"; 
        }
    }
}

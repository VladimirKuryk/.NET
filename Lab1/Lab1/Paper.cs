using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Paper
    {
        public string publicationName;
        public Person author;
        public DateTime publicationDate;

        public Paper(string pName, Person person, DateTime publDate) {
            publicationName = pName;
            author = person;
            publicationDate = publDate;
        }

        public Paper() {
            publicationName = "";
            author = new Person();
            publicationDate = new DateTime(2017, 9, 10);
        }

        public override string ToString()
        {
            return "Publication Name: " + publicationName + "; Author: " + author + "; Date: " + publicationDate.ToString() + ";";
        }
    }
}

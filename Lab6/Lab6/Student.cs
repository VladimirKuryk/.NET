using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /*[Couple("Girl", 0.7, "Girl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    [Couple("PrettyGirl", 0.6 , "Girl")]
    [Couple("Girl", 0.3, "SmartGirl")]
    [Couple("SmartGirl", 0.7, "SmartGirl")]
    [Couple("PrettyGirl", 0.2, "SmartGirl")]
    [Couple("Girl", 0.8, "PrettyGirl")]
    [Couple("SmartGirl", 0.1, "PrettyGirl")]
    [Couple("PrettyGirl", 0.2, "PrettyGirl")]
    [Couple("Girl", 0.8, "Student")]
    [Couple("SmartGirl", 0.1, "Student")]
    [Couple("PrettyGirl", 0.2, "Student")]
    [Couple("Girl", 0.8, "Botan")]
    [Couple("SmartGirl", 0.5, "Botan")]
    [Couple("PrettyGirl", 0.2, "Botan")]*/

    [Couple("Girl", 0.7, "Girl")]
    [Couple("PrettytGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    class Student : Human
    {
        public Student()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public Student(string name, string surname, string fname)
        {
            Name = name;
            Surname = surname;
            FathersName = fname;
        }

        public override IEnumerable<object> partOfPair()
        {
            Type t = typeof(Student);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs)
            {
                //Console.WriteLine(coupleAttr.Pair);
                yield return coupleAttr;
            }
        }
    }
}

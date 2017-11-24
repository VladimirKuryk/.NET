using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /*[Couple("Girl", 0.4, "Girl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    [Couple("PrettyGirl", 0.1, "Girl")]
    [Couple("Girl", 0.26, "SmartGirl")]
    [Couple("SmartGirl", 0.13, "SmartGirl")]
    [Couple("PrettyGirl", 0.76, "SmartGirl")]
    [Couple("Girl", 0.85, "PrettyGirl")]
    [Couple("SmartGirl", 0.12, "PrettyGirl")]
    [Couple("PrettyGirl", 0.7, "PrettyGirl")]
    [Couple("Girl", 0.821, "Student")]
    [Couple("SmartGirl", 0.15, "Student")]
    [Couple("PrettyGirl", 0.28, "Student")]
    [Couple("Girl", 0.31, "Botan")]
    [Couple("SmartGirl", 0.45, "Botan")]
    [Couple("PrettyGirl", 0.52, "Botan")]*/

    [Couple("Girl", 0.7, "SmartGirl")]
    [Couple("PrettytGirl", 0.7, "PrettyGirl")]
    [Couple("SmartGirl", 0.8, "Book")]
    class Botan : Human
    {
        public Botan()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public Botan(string name, string surname, string fname)
        {
            Name = name;
            Surname = surname;
            FathersName = fname;
        }

        public override IEnumerable<object> partOfPair()
        {
            Type t = typeof(Botan);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs)
            {
                //Console.WriteLine(coupleAttr.Pair);
                yield return coupleAttr;
            }
        }
    }
}

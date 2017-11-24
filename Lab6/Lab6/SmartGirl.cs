using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /*[Couple("Botan", 0.45, "Girl")]
    [Couple("Botan", 0.95, "SmartGirl")]
    [Couple("Botan", 0.21, "PrettyGirl")]
    [Couple("Botan", 0.85, "Student")]
    [Couple("Botan", 0.02, "Botan")]

    [Couple("Student", 0.7, "Girl")]
    [Couple("Student", 0.3, "SmartGirl")]
    [Couple("Student", 0.2, "PrettyGirl")]
    [Couple("Student", 0.23, "Botan")]
    [Couple("Student", 0.45, "Student")]*/

    [Couple("Student", 0.2, "Girl")]
    [Couple("Botan", 0.5, "Book")]
    class SmartGirl : Human
    {
        public SmartGirl()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }
        public SmartGirl(string name, string surname, string fname)
        {
            Name = name;
            Surname = surname;
            FathersName = fname;
        }

        public override IEnumerable<object> partOfPair()
        {
            Type t = typeof(SmartGirl);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs)
            {
                //Console.WriteLine(coupleAttr.Pair);
                yield return coupleAttr;
            }
        }
    }
}

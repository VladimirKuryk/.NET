using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /*[Couple("Botan", 0.4, "Girl")]
    [Couple("Botan", 0.63, "SmartGirl")]
    [Couple("Botan", 0.45, "PrettyGirl")]
    [Couple("Botan", 0.32, "Student")]
    [Couple("Botan", 0.24, "Botan")]

    [Couple("Student", 0.48, "Girl")]
    [Couple("Student", 0.33, "SmartGirl")]
    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Student", 0.7, "Botan")]
    [Couple("Student", 0.2, "Student")]*/

    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Botan", 0.1, "PrettyGirl")]
    class PrettyGirl : Human
    {
        public PrettyGirl()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public PrettyGirl(string name, string surname, string fname)
        {
            Name = name;
            Surname = surname;
            FathersName = fname;
        }

        public override IEnumerable<object> partOfPair()
        {
            Type t = typeof(PrettyGirl);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs)
            {
                //Console.WriteLine(coupleAttr.Pair);
                yield return coupleAttr;
            }
        }
    }
}

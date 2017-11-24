using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /*[Couple("Botan", 0.32, "Girl")]
    [Couple("Botan", 0.67, "SmartGirl")]
    [Couple("Botan", 0.23, "PrettyGirl")]
    [Couple("Botan", 0.12, "Student")]
    [Couple("Botan", 0.97, "Botan")]
    
    [Couple("Student", 0.27, "Girl")]
    [Couple("Student", 0.6, "SmartGirl")]
    [Couple("Student", 0.3, "PrettyGirl")]
    [Couple("Student", 0.1, "Botan")]
    [Couple("Student", 0.7, "Student")]*/

    [Couple("Student", 0.7, "Girl")]
    [Couple("Botan", 0.3, "SmartGirl")]
    class Girl : Human
    {
        public Girl()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }
        public Girl(string name, string surname, string fname)
        {
            Name = name;
            Surname = surname;
            FathersName = fname;
        }

        public override IEnumerable<object> partOfPair()
        {
            Type t = typeof(Girl);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs)
            {
                //Console.WriteLine(coupleAttr.Pair);
                yield return coupleAttr;
            }
        }
    }
}

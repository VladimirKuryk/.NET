using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{    
    class Human : IHasName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FathersName { get; set; }
        public string ClassName { get; }

        public virtual IEnumerable<object> partOfPair() {
            Type t = typeof(Human);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (CoupleAttribute coupleAttr in attrs) {
                //Console.WriteLine(coupleAttr.Pair);
                yield return coupleAttr;
            }
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + FathersName;
        }
    }   
}

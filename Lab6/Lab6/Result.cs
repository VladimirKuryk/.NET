using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Result
    {
        public string Name { get; set; }
        public string ClassType { get; set; }
        public bool Like { get; set; }

        public Result() {
            Name = "None";
            ClassType = "None";
            Like = false;
        }

        public override string ToString() {
            return "Name: " + Name+";   ClassType: " + ClassType + ";   Like: " + Like + ";";
        }
    }
}

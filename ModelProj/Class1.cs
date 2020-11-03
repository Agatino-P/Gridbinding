using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelProj
{
    public class PP
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Value { get; set; }

        public PP(string name, string desc, double value)
        {
            Name = name;
            Desc = desc;
            Value = value;
        }
        public override string ToString()
        {
            return $"Name: {Name} Desc:{Desc} Value {Value}";
        }
    }
}

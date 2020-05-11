using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MPropSandbox
{
    public class MpropField
    {
        public string DataModelName { get; set; }
        public List<string> DataFileNames { get; set; } = new List<string>();
        public List<int> Years { get; set; } = new List<int>();
        public PropertyInfo PropertyInfo { get; set; }
    }
}

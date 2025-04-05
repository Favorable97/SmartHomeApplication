using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Enumerables
{
    public class SqlParam(string Name, object Value)
    {
        public string Name { get; init; } = Name;
        public object Value { get; init; } = Value;
    }
}

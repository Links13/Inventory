using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class StringFormatException : Exception
    {
        public StringFormatException(String name) : base(name) { }
    }
}

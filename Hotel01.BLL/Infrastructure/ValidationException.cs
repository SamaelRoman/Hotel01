using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.BLL.Infrastructure
{
    class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string Msg, string Property):base(Msg)
        {
            this.Property = Property;
        }
    }
}

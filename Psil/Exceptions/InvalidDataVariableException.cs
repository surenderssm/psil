using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psil.Exceptions
{
    /// <summary>
    /// Exception for InvalidDataVariableException
    /// </summary>
    class InvalidDataVariableException : BaseException
    {
        private const string title = "Invalid Data Variable Value.Data Variable can only contains a double value.Check the Command";
        public InvalidDataVariableException(string message)
            : base(string.Concat(title, message))
        {
        }

        public InvalidDataVariableException(string message, Exception inner)
            : base(string.Concat(title, message), inner)
        {
        }
    }
}

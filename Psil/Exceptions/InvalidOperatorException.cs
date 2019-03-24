using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psil.Exceptions
{
    /// <summary>
    /// Exception for Invalid Input/Command
    /// </summary>
    class InvalidOperatorException : BaseException
    {
        private const string title = "Invalid Operator.Check the Command";
        public InvalidOperatorException(string message)
            : base(string.Concat(title, message))
        {
        }

        public InvalidOperatorException(string message, Exception inner)
            : base(string.Concat(title, message), inner)
        {
        }
    }
}

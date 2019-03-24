

namespace Psil.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Exception for UnBindedVariableException
    /// </summary>
    public class InvalidTokenException : BaseException
    {
        private const string title = "Invalid Token.Check the Command";

        public InvalidTokenException(string message)
            : base(string.Concat(title, message))
        {
        }

        public InvalidTokenException(string message, Exception inner)
            : base(string.Concat(title, message), inner)
        {
        }
    }
}

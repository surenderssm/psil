

namespace Psil.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Exception for IINvalidBindStatements
    /// </summary>
    public class InvalidBindStatementException : BaseException
    {
        private const string title = "Invalid Bind Statement.Check the Command";

        public InvalidBindStatementException(string message)
            : base(string.Concat(title, message))
        {
        }

        public InvalidBindStatementException(string message, Exception inner)
            : base(string.Concat(title, message), inner)
        {
        }
    }
}

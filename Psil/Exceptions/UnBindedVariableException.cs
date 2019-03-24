

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
    public class UnBindedVariableException : BaseException
    {
        private const string title = "Invalid Bind Statement.Check the Command";

        public UnBindedVariableException(string message)
            : base(string.Concat(title, message))
        {
        }

        public UnBindedVariableException(string message, Exception inner)
            : base(string.Concat(title, message), inner)
        {
        }
    }
}

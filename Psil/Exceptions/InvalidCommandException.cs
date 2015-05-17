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
    class InvalidCommandException : BaseException
    {
        private const string title = "Invalid Command.Check the Command";
        public InvalidCommandException(string message)
            : base(string.Concat(title, message))
        {
        }

        public InvalidCommandException(string message, Exception inner)
            : base(string.Concat(title, message), inner)
        {
        }
    }
}

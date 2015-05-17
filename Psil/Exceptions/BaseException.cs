﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psil.Exceptions
{
    public abstract class BaseException : Exception
    {
        

        public BaseException()
        {
        }

        public BaseException(string message)
            : base(message)
        {
        }

        public BaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

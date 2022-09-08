using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException() : base() { }

        public ConflictException(string message) : base(message) { }

        public ConflictException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}

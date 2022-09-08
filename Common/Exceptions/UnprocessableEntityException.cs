using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException() : base() { }

        public UnprocessableEntityException(string message) : base(message) { }

        public UnprocessableEntityException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}

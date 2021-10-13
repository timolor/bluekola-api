using System;

namespace Bluekola.Api.Common.Exceptions
{
    public class SystemException : Exception
    {
        public SystemException(string message) : base(message)
        {
        }
    }
}
using System;

namespace Imdb.Domain.Shared.Exceptions
{
    public class CoreException : Exception
    {
        public new readonly string Message;

        public CoreException(string message)
        {
            Message = message;
        }
    }
}

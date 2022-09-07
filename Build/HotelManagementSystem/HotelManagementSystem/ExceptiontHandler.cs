using System;
using System.Runtime.Serialization;

namespace HotelManagementSystem
{
    [Serializable]
    internal class ExceptiontHandler : Exception
    {
        public ExceptiontHandler()
        {
        }

        public ExceptiontHandler(string message) : base(message)
        {
        }

        public ExceptiontHandler(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptiontHandler(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
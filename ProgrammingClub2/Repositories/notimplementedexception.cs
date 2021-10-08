using System;
using System.Runtime.Serialization;

namespace ProgrammingClub2.Repositories
{
    [Serializable]
    internal class notimplementedexception : Exception
    {
        public notimplementedexception()
        {
        }

        public notimplementedexception(string message) : base(message)
        {
        }

        public notimplementedexception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected notimplementedexception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
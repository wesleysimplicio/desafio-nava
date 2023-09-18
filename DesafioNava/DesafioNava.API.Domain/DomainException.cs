using System;
using System.Runtime.Serialization;

namespace DesafioNava.API.Domain
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}


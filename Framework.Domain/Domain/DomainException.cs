using System;

namespace Framework.Domain
{
    public class DomainException : Exception
    {
        public string _message { get; set; }
         
        public DomainException(string message) : base(message)
        {
            _message = message;
        }
    }
}

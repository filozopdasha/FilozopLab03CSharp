using System;

namespace FilozopLab03.Exceptions
{
    class WrongEmailException : Exception
    {
        public WrongEmailException() : base("Email is invalid") { }
        public WrongEmailException(string message) : base(message) { }
    }

}

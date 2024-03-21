using System;

namespace FilozopLab03.Exceptions
{
    class DateIsTooOldException : Exception
    {
        public DateIsTooOldException() : base("You are probably dead") { }
        public DateIsTooOldException(string message) : base(message) { }


    }
}

namespace FitMe.Domain.Exercising.Exceptions
{
    using System;
    using FitMe.Domain.Common;

    public class InvalidInstructorException : BaseDomainException
    {
        public InvalidInstructorException()
        {
        }

        public InvalidInstructorException(string error) => this.Error = error;
    }
}

namespace FitMe.Domain.Exercising.Exceptions
{
    using System;
    using FitMe.Domain.Common;

    public class InvalidExеrciseException : BaseDomainException
    {
        public InvalidExеrciseException()
        {
        }

        public InvalidExеrciseException(string error) => this.Error = error;
    }
}

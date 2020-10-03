namespace FitMe.Domain.Exercising.Exceptions
{
    using System;
    using FitMe.Domain.Common;

    public class InvalidMuscleException : BaseDomainException
    {
        public InvalidMuscleException()
        {
        }

        public InvalidMuscleException(string error) => this.Error = error;
    }
}

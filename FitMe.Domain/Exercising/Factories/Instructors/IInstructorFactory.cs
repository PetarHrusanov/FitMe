namespace FitMe.Domain.Exercising.Factories.Instructors
{
    using System;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Instructors;

    public interface IInstructorFactory : IFactory<Instructor>
    {
        IInstructorFactory WithName(string name);

        IInstructorFactory WithDescription(string description);

        IInstructorFactory WithPhoneNumber(string phoneNumber);
    }
}

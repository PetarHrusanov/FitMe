using System;
using FitMe.Domain.Exercising.Models.Instructors;

namespace FitMe.Domain.Exercising.Factories.Instructors
{
    public class InstructorFactory : IInstructorFactory
    {
        private string instructorName = default!;
        private string instructorDescription = default!;
        private string instructorPhoneNumber = default!;

        public IInstructorFactory WithName(string name)
        {
            this.instructorName = name;
            return this;
        }

        public IInstructorFactory WithDescription(string description)
        {
            this.instructorDescription = description;
            return this;
        }

        public IInstructorFactory WithPhoneNumber(string phoneNumber)
        {
            this.instructorPhoneNumber = phoneNumber;
            return this;
        }

        //string name, string description, string phoneNumber

        public Instructor Build() => new Instructor(this.instructorName, this.instructorDescription, this.instructorPhoneNumber);

        public Instructor Build(string name, string description, string phoneNumber)
            => this
                .WithName(name)
                .WithDescription(description)
                .WithPhoneNumber(phoneNumber)
                .Build();
    }
}

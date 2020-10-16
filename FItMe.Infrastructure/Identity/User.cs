namespace FitMe.Infrastructure.Identity
{
    using Application.Identity;
    using FitMe.Domain.Exercising.Exceptions;
    using FitMe.Domain.Exercising.Models.Instructors;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Instructor? Instructor { get; private set; }

        public void BecomeInstructor(Instructor instructor)
        {
            if (this.Instructor != null)
            {
                throw new InvalidInstructorException($"User '{this.UserName}' is already a instructor.");
            }

            this.Instructor = instructor;
        }
    }
}

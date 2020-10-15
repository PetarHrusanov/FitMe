namespace FitMe.Application.Identity
{
    using FitMe.Domain.Exercising.Models.Instructors;

    public interface IUser
    {
        void BecomeInstructor(Instructor instructor);
    }
}

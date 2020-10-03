namespace FitMe.Domain.Exercising.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Instructors;

    public interface IInstructorDomainRepository :IDomainRepository<Instructor>
    {
        Task<Instructor> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetInstructorId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasExercise(int instructorId, int ExerciseId, CancellationToken cancellationToken = default);
    }
}

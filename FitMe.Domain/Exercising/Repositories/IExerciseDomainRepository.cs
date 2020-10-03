namespace FitMe.Domain.Exercising.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Exercises;

    public interface IExerciseDomainRepository :IDomainRepository<Exercise>
    {
        Task<Exercise> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Muscle> GetMuscle(
            string muscleName,
            CancellationToken cancellationToken = default);

        Task<Complexity> GetComplexity(
            Complexity complexity,
            CancellationToken cancellationToken = default);

        // consider complexity search

        //Task<Complexity> GetCategory(
        //    int muscleId,
        //    CancellationToken cancellationToken = default);
    }
}

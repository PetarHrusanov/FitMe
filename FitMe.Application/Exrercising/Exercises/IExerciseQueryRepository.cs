namespace FitMe.Application.Exrercising.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common.Contracts;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;
    using FitMe.Application.Exrercising.Exercises.Queries.Details;
    using FitMe.Application.Exrercising.Exercises.Queries.Muscle;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Exercises;
    using FitMe.Domain.Exercising.Models.Instructors;

    public interface IExerciseQueryRepository : IQueryRepository<Exercise>
    {
        Task<IEnumerable<TOutputModel>> GetExercisesListings<TOutputModel>(
            Specification<Exercise> exerciseSpecification,
            Specification<Instructor> instructorSpecification,
            ExercisesSortOrder exercisesSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<ExerciseDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<GetExerciseMuscleOutputModel>> GetExercisesMuscle(
            //string muscleName,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<Exercise> exerciseSpecification,
            Specification<Instructor> instructorSpecification,
            CancellationToken cancellationToken = default);
    }
}

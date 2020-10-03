namespace FitMe.Application.Exrercising.Instructors
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common.Contracts;
    using FitMe.Application.Exrercising.Instructors.Queries.Common;
    using FitMe.Application.Exrercising.Instructors.Queries.Details;
    using FitMe.Domain.Exercising.Models.Instructors;

    public interface IInstructorQueryRepository : IQueryRepository<Instructor>
    {
        Task<InstructorDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<InstructorOutputModel> GetDetailsByExerciseId(int carAdId, CancellationToken cancellationToken = default);

    }
}

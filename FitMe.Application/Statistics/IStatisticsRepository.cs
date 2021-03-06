﻿namespace FitMe.Application.Statistics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Statistics.Models;
    using Queries.Current;

    public interface IStatisticsRepository : IQueryRepository<Statistics>
    {
        Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default);

        Task<int> GetExerciseViews(int exerciseId, CancellationToken cancellationToken = default);

        Task IncrementExercises(CancellationToken cancellationToken = default);
    }
}

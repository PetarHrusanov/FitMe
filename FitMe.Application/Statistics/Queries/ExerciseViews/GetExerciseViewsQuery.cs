namespace FitMe.Application.Statistics.Queries.ExerciseViews
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetExerciseViewsQuery : IRequest<int>
    {
        public int ExerciseId { get; set; }

        public class GetCarAdViewsQueryHandler : IRequestHandler<GetExerciseViewsQuery, int>
        {
            private readonly IStatisticsRepository statistics;

            public GetCarAdViewsQueryHandler(IStatisticsRepository statistics)
                => this.statistics = statistics;

            public Task<int> Handle(
                GetExerciseViewsQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetExerciseViews(request.ExerciseId, cancellationToken);
        }
    }
}

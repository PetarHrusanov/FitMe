namespace FitMe.Application.Exrercising.Exercises.Queries.Search
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;
    using MediatR;

    public class SearchExercisesQuery : ExerciseQuery, IRequest<SearchExercisesOutputModel>
    {
        public class SearchExercisesQueryHandler : ExercisesQueryHandler, IRequestHandler<
            SearchExercisesQuery,
            SearchExercisesOutputModel>
        {
            public SearchExercisesQueryHandler(IExerciseQueryRepository exerciseRepository)
                : base(exerciseRepository)
            {
            }

            public async Task<SearchExercisesOutputModel> Handle(
                SearchExercisesQuery request,
                CancellationToken cancellationToken)
            {
                var exerciseListings = await base.GetCarAdListings<ExerciseOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchExercisesOutputModel(exerciseListings, request.Page, totalPages);
            }
        }
    }
}

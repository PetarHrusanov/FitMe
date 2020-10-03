namespace FitMe.Application.Exrercising.Exercises.Queries.Muscle
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetExerciseMusclesQuery : IRequest<IEnumerable<GetExerciseMuscleQuery>>
    {
        public class GetCarAdCategoriesQueryHandler : IRequestHandler<
            GetExerciseMusclesQuery,
            IEnumerable<GetExerciseMuscleQuery>>
        {
            private readonly IExerciseQueryRepository exerciseRepository;

            public GetExerciseMusclesQuery(IExerciseQueryRepository exerciseRepositor)
                => this.exerciseRepositor = exerciseRepositor;

            public async Task<IEnumerable<GetExerciseMuscleQuery>> Handle(
                GetExerciseMusclesQuery request,
                CancellationToken cancellationToken)
                => await this.exerciseRepository.GetCarAdCategories(cancellationToken);
        }
    }
}

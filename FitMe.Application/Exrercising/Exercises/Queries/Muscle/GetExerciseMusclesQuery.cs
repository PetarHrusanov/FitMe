namespace FitMe.Application.Exrercising.Exercises.Queries.Muscle
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetExerciseMusclesQuery : IRequest<IEnumerable<GetExerciseMuscleOutputModel>>
    {
        public class GetExerciseMuscleQueryHandler : IRequestHandler<
            GetExerciseMusclesQuery,
            IEnumerable<GetExerciseMuscleOutputModel>>
        {
            private readonly IExerciseQueryRepository exerciseRepository;

            public GetExerciseMuscleQueryHandler(IExerciseQueryRepository exerciseRepository)
                => this.exerciseRepository = exerciseRepository;

            public async Task<IEnumerable<GetExerciseMuscleOutputModel>> Handle(
                GetExerciseMusclesQuery request,
                CancellationToken cancellationToken)
                => await this.exerciseRepository.GetExercisesMuscle(cancellationToken);
        }
    }
}

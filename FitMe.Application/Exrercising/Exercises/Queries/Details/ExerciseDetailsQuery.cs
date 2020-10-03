namespace FitMe.Application.Exrercising.Exercises.Queries.Details
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Exrercising.Instructors;
    using MediatR;

    public class ExerciseDetailsQuery : EntityCommand<int>, IRequest<ExerciseDetailsOutputModel>
    {
        public class ExeciseDetailsQueryHandler : IRequestHandler<ExerciseDetailsQuery, ExerciseDetailsOutputModel>
        {
            private readonly IExerciseQueryRepository exerciseRepository;
            private readonly IInstructorQueryRepository instructorRepository;

            public ExeciseDetailsQueryHandler(
                IExerciseQueryRepository exerciseRepository,
                IInstructorQueryRepository instructorRepository)
            {
                this.exerciseRepository = exerciseRepository;
                this.instructorRepository = instructorRepository;
            }

            public async Task<ExerciseDetailsOutputModel> Handle(
                ExerciseDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var exerciseDetails = await this.exerciseRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                exerciseDetails.Instructor = await this.instructorRepository.GetDetailsByExerciseId(
                    request.Id,
                    cancellationToken);

                return exerciseDetails;
            }
        }
    }
}

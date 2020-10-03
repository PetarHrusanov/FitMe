namespace FitMe.Application.Exrercising.Exercises.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Common.Contracts;
    using FitMe.Application.Exrercising.Exercises.Commands.Common;
    using FitMe.Application.Exrercising.Instructors;
    using FitMe.Domain.Exercising.Repositories;
    using MediatR;

    public class DeleteExerciseCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteCarAdCommandHandler : IRequestHandler<DeleteExerciseCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IExerciseDomainRepository exerciseRepository;
            private readonly IInstructorDomainRepository instructorRepository;

            public DeleteCarAdCommandHandler(
                ICurrentUser currentUser,
                IExerciseDomainRepository exerciseRepository,
                IInstructorDomainRepository instructorRepository)
            {
                this.currentUser = currentUser;
                this.exerciseRepository = exerciseRepository;
                this.instructorRepository = instructorRepository;
            }

            public async Task<Result> Handle(
                DeleteExerciseCommand request,
                CancellationToken cancellationToken)
            {
                var instructorHasExercise = await this.currentUser.InstructorHasExercise(
                    this.instructorRepository,
                    request.Id,
                    cancellationToken);

                if (!instructorHasExercise)
                {
                    return instructorHasExercise;
                }

                return await this.exerciseRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}

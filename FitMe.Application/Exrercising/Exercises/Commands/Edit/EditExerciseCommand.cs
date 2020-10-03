namespace FitMe.Application.Exrercising.Exercises.Commands.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Common.Contracts;
    using FitMe.Application.Exrercising.Exercises.Commands.Common;
    using FitMe.Domain.Common.Models;
    using FitMe.Domain.Exercising.Models.Exercises;
    using FitMe.Domain.Exercising.Repositories;
    using MediatR;

    public class EditExerciseCommand : ExerciseCommand<EditExerciseCommand>, IRequest<Result>
    {
        public class EditCarAdCommandHandler : IRequestHandler<EditExerciseCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IExerciseDomainRepository exerciseRepository;
            private readonly IInstructorDomainRepository instructorRepository;

            public EditCarAdCommandHandler(
                ICurrentUser currentUser,
                IExerciseDomainRepository exerciseRepository,
                IInstructorDomainRepository instructorRepository)
            {
                this.currentUser = currentUser;
                this.exerciseRepository = exerciseRepository;
                this.instructorRepository = instructorRepository;
            }

            public async Task<Result> Handle(
                EditExerciseCommand request,
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

                var muscle = await this.exerciseRepository.GetMuscle(
                    request.Muscle,
                    cancellationToken);

                var exercise = await this.exerciseRepository
                    .Find(request.Id, cancellationToken);

                exercise
                    .ChangeComplexity(Enumeration.FromValue<Complexity>(request.Complexity))
                    .ChangeDescription(request.Description)
                    .ChangeInstruction(request.Instruction);

                await this.exerciseRepository.Save(exercise, cancellationToken);

                return Result.Success;
            }
        }
    }
}

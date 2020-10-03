namespace FitMe.Application.Exrercising.Exercises.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common.Contracts;
    using FitMe.Application.Exrercising.Exercises.Commands.Common;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;
    using FitMe.Domain.Common.Models;
    using FitMe.Domain.Exercising.Factories.Exercises;
    using FitMe.Domain.Exercising.Models.Exercises;
    using FitMe.Domain.Exercising.Repositories;
    using MediatR;

    public class CreateExerciseCommand : ExerciseCommand<CreateExerciseCommand>, IRequest<CreateExerciseOutputModel>
    {
        public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, CreateExerciseOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IInstructorDomainRepository instructorRepository;
            private readonly IExerciseDomainRepository exerciseRepository;
            private readonly IExerciseFactory exerciseFactory;

            public CreateExerciseCommandHandler(
                ICurrentUser currentUser,
                IInstructorDomainRepository instructorRepository,
                IExerciseDomainRepository exerciseRepositoryy,
                IExerciseFactory exerciseFactory)
            {
                this.currentUser = currentUser;
                this.instructorRepository = instructorRepository;
                this.exerciseRepository = exerciseRepositoryy;
                this.exerciseFactory = exerciseFactory;
            }

            public async Task<CreateExerciseOutputModel> Handle(
                CreateExerciseCommand request,
                CancellationToken cancellationToken)
            {
                var instructor = await this.instructorRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var muscle = await this.exerciseRepository.GetMuscle(
                    request.Muscle,
                    cancellationToken);

                var factory = this.exerciseFactory.WithMuscle(muscle);
                //var factory = muscle == null
                //    ? this.exerciseFactory.WithMuscle(request.Muscle)
                //    : this.exerciseFactory.WithMuscle(muscle);

                var exercise = factory
                    .WithName(request.Name)
                    .WithDescription(request.Description)
                    .WithInstruction(request.Instruction)
                    .WithComplexity(Enumeration.FromValue<Complexity>(request.Complexity))
                    .WithMuscle(muscle)
                    .Build();

                instructor.AddExercise(exercise);

                await this.exerciseRepository.Save(exercise, cancellationToken);

                return new CreateExerciseOutputModel(exercise.Id);
            }
        }
    }
}

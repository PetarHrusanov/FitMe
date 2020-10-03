namespace FitMe.Application.Exrercising.Exercises.Commands.Create
{
    using System;
    using FitMe.Application.Exrercising.Exercises.Commands.Common;
    using FluentValidation;

    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator(IExerciseQueryRepository exerciseRepository)
            => this.Include(new ExerciseCommandValidator<CreateExerciseCommand>(exerciseRepository));
    }
}

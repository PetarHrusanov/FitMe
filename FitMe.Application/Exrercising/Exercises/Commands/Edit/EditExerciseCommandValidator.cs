namespace FitMe.Application.Exrercising.Exercises.Commands.Edit
{
    using System;
    using FitMe.Application.Exrercising.Exercises.Commands.Common;
    using FluentValidation;

    public class EditExerciseCommandValidator : AbstractValidator<EditExerciseCommand>
    {
        public EditExerciseCommandValidator(IExerciseQueryRepository exerciseRepostiroy)
            => this.Include(new ExerciseCommandValidator<EditExerciseCommand>(exerciseRepostiroy));
    }
}

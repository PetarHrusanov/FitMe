namespace FitMe.Application.Exrercising.Exercises.Commands.Common
{
    using System;
    using FitMe.Application.Common;
    using FitMe.Domain.Common.Models;
    using FitMe.Domain.Exercising.Models.Exercises;
    using FluentValidation;

    using static Domain.Exercising.Models.ModelConstants.Common;
    using static Domain.Exercising.Models.ModelConstants.Description;

    public class ExerciseCommandValidator<TCommand> : AbstractValidator<ExerciseCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ExerciseCommandValidator(IExerciseQueryRepository exerciseRepository)
        {
            this.RuleFor(c => c.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Description)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();

            this.RuleFor(c => c.Instruction)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();

            this.RuleFor(c => c.Complexity)
                .Must(Enumeration.HasValue<Complexity>)
                .WithMessage("Complexity is not valid.");

            // Study that case
            //this.RuleFor(c => c.Muscle)
            //    .MustAsync(async (muscle, token) => await exerciseRepository)
            //    .WithMessage("'{PropertyName}' does not exist.");

        }
    }
}

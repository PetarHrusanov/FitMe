namespace FitMe.Application.Exrercising.Instructors.Commands.Edit
{
    using System;
    using FluentValidation;
    using static Domain.Exercising.Models.ModelConstants.Common;
    using static Domain.Exercising.Models.ModelConstants.PhoneNumber;

    public class EditInstructorCommandValidator : AbstractValidator<EditInstructorCommand>
    {
        public EditInstructorCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}

namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FitMe.Domain.Common;
    using FitMe.Domain.Common.Models;
    using FitMe.Domain.Exercising.Exceptions;

    using static ModelConstants.Common;
    using static ModelConstants.Description;

    public class Exercise :Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Muscle> EnteredMuscles
            = new MuscleData().GetData().Cast<Muscle>();

        internal Exercise(
            string name,
            string description,
            string instruction,
            Complexity complexity,
            Muscle muscle)
        {
            this.Validate(name, description, instruction);

            this.ValidateMuscle(muscle);

            this.Name = name;
            this.Description = description;
            this.Instruction = instruction;

            this.Muscle = muscle;

            this.Complexity = complexity;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Instruction { get; private set; }

        public Muscle Muscle { get; private set; }

        public Complexity Complexity { get; private set; }

        public Exercise ChangeDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public Exercise ChangeInstruction(string instruction)
        {
            this.ValidateDescription(instruction);
            this.Instruction = instruction;

            return this;
        }

        public Exercise ChangeComplexity(Complexity complexity)
        {
            this.Complexity = complexity;
            return this;
        }

        private void Validate(string name, string description, string instruction)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
            this.ValidateDescription(instruction);
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidExеrciseException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForValidDescription<InvalidExеrciseException>(
                description,
                nameof(this.Description));

        private void ValidateMuscle(Muscle muscle)
        {
            var muscleName = muscle?.Name;

            if (EnteredMuscles.Any(c => c.Name == muscleName))
            {
                return;
            }

            var allowedMuscleName = string.Join(", ", EnteredMuscles.Select(c => $"'{c.Name}'"));

            throw new InvalidExеrciseException($"'{muscleName}' is not a valid muscle. Allowed values are: {allowedMuscleName}.");
        }

    }
}

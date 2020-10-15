namespace FitMe.Domain.Exercising.Models.Exercises
{
    using FitMe.Domain.Common.Models;
    using FitMe.Domain.Exercising.Exceptions;

    using static ModelConstants.Common;

    public class Muscle : Entity<int>
    {
        internal Muscle(string name, string description, MuscleGroup muscleGroup)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;

            this.MuscleGroup = muscleGroup;


        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public MuscleGroup MuscleGroup { get; private set; }

        private void Validate(string name, string description)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
        }


        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidMuscleException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForValidDescription<InvalidMuscleException>(
                description,
                nameof(this.Description));
    }
}

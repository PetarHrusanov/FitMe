namespace FitMe.Domain.Exercising.Models.Instructors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FitMe.Domain.Common;
    using FitMe.Domain.Common.Models;
    using FitMe.Domain.Exercising.Events.Instructor;
    using FitMe.Domain.Exercising.Exceptions;
    using FitMe.Domain.Exercising.Models.Exercises;
    using static ModelConstants.Common;

    public class Instructor : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Exercise> exercises;

        internal Instructor(string name, string description, string phoneNumber)
        {
            this.Validate(name);
            this.ValidateDescription(description);

            this.Name = name;
            this.Description = description;
            this.PhoneNumber = phoneNumber;

            this.exercises = new HashSet<Exercise>();
        }

        //private Instructor(string name)
        //{
        //    this.Name = name;
        //    this.PhoneNumber = default!;

        //    this.exercises = new HashSet<Exercise>();
        //}

        public string Name { get; private set; }
        public string Description { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Instructor UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public Instructor UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public Instructor UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<Exercise> Exercises => this.exercises.ToList().AsReadOnly();

        public void AddExercise(Exercise exercise)
        {
            this.exercises.Add(exercise);

            this.RaiseEvent(new ExerciseAddedEvent());
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidInstructorException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForValidDescription<InvalidInstructorException>(
                description,
                nameof(this.Description));
    }
}

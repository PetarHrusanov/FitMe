namespace FitMe.Domain.Exercising.Factories.Exercises
{
    using System;
    using FitMe.Domain.Exercising.Exceptions;
    using FitMe.Domain.Exercising.Models.Exercises;

    public class ExerciseFactory : IExerciseFactory
    {
        private string exerciseName = default!;
        private string exerciseDescription = default!;
        private string exerciseInstruction = default!;

        private Complexity exerciseComplexity = default!;
        private Muscle exerciseMuscle = default!;

        private bool complexitySet = false;
        private bool muscleSet = false;

        public IExerciseFactory WithName(string name)
        {
            this.exerciseName = name;
            return this;
        }

        public IExerciseFactory WithDescription(string decription)
        {
            this.exerciseDescription = decription;
            return this;
        }

        public IExerciseFactory WithInstruction(string instruction)
        {
            this.exerciseInstruction = instruction;
            return this;
        }

        public IExerciseFactory WithComplexity(Complexity complexity)
        {
            this.exerciseComplexity = complexity;
            this.complexitySet = true;
            return this;
        }

        public IExerciseFactory WithMuscle(string name, string description, MuscleGroup muscleGroup)
            => this.WithMuscle(new Muscle(name, description, muscleGroup));

        public IExerciseFactory WithMuscle(Muscle muscle)
        {
            this.exerciseMuscle = muscle;
            this.muscleSet = true;
            return this;
        }

        public Exercise Build()
        {
            if (!this.complexitySet || !this.muscleSet)
            {
                throw new InvalidExеrciseException("Complexity and muscle must be set.");
            }

            return new Exercise(
                this.exerciseName,
                this.exerciseInstruction,
                this.exerciseDescription,
                this.exerciseComplexity,
                this.exerciseMuscle);
        }
    }
}

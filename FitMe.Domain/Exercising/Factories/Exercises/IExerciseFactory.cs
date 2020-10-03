namespace FitMe.Domain.Exercising.Factories.Exercises
{
    using System;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Exercises;

    public interface IExerciseFactory :IFactory<Exercise>
    {
        IExerciseFactory WithName(string name);

        IExerciseFactory WithDescription(string decription);

        IExerciseFactory WithInstruction(string instruction);

        IExerciseFactory WithComplexity(Complexity complexity);

        IExerciseFactory WithMuscle(string name, string description, MuscleGroup muscleGroup);

        IExerciseFactory WithMuscle(Muscle muscle);

    }
}

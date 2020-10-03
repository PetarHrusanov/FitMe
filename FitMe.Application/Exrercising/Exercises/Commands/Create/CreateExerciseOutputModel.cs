using System;
namespace FitMe.Application.Exrercising.Exercises.Commands.Create
{
    public class CreateExerciseOutputModel
    {
        public CreateExerciseOutputModel(int exerciseId)
            => this.ExerciseId = exerciseId;

        public int ExerciseId { get; }
    }
}

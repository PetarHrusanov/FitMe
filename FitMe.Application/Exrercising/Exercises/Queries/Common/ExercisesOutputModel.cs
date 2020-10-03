namespace FitMe.Application.Exrercising.Exercises.Queries.Common
{
    using System;
    using System.Collections.Generic;

    public abstract class ExercisesOutputModel<TExerciseOutputModel>
    {
        internal ExercisesOutputModel(
            IEnumerable<TExerciseOutputModel> exercises,
            int page,
            int totalPages)
        {
            this.Exercises = exercises;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TExerciseOutputModel> Exercises { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}

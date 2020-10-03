namespace FitMe.Application.Exrercising.Exercises.Queries.Search
{
    using System;
    using System.Collections.Generic;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;

    public class SearchExercisesOutputModel : ExercisesOutputModel<ExerciseOutputModel>
    {
        public SearchExercisesOutputModel(
            IEnumerable<ExerciseOutputModel> exercises,
            int page,
            int totalPages)
            : base(exercises, page, totalPages)
        {
        }
    }
}

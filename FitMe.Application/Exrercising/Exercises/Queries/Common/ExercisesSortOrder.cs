namespace FitMe.Application.Exrercising.Exercises.Queries.Common
{
    using System;
    using System.Linq.Expressions;
    using FitMe.Application.Common;
    using FitMe.Domain.Exercising.Models.Exercises;

    public class ExercisesSortOrder : SortOrder<Exercise>
    {
        public ExercisesSortOrder(string? sortBy, string? order)
            : base(sortBy, order)
        {
        }

        public override Expression<Func<Exercise, object>> ToExpression()
            => this.SortBy switch
            {
                "complexity" => exercise => exercise.Complexity,
                "muscle" => exercise => exercise.Muscle.Name,
                _ => carAd => carAd.Id
            };
    }
}

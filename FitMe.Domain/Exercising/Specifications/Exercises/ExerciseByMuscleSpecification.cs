using System;
using System.Linq.Expressions;
using FitMe.Domain.Common;
using FitMe.Domain.Exercising.Models.Exercises;

namespace FitMe.Domain.Exercising.Specifications.Exercises
{
    public class ExerciseByMuscleSpecification : Specification<Exercise>
    {
        private readonly string? muscle;

        public ExerciseByMuscleSpecification(string? muscle)
           => this.muscle = muscle;

        protected override bool Include => this.muscle != null;

        public override Expression<Func<Exercise, bool>> ToExpression()
            => exercise => exercise.Muscle.Name == this.muscle;
    }
}

using System;
using System.Linq.Expressions;
using FitMe.Domain.Common;
using FitMe.Domain.Exercising.Models.Exercises;

namespace FitMe.Domain.Exercising.Specifications.Exercises
{
    public class ExerciseByComplexitySpecification : Specification<Exercise>
    {
        private readonly Complexity complexity;

        public ExerciseByComplexitySpecification(Complexity complexity)
           => this.complexity = complexity;

        protected override bool Include => this.complexity != null;

        public override Expression<Func<Exercise, bool>> ToExpression()
            => exercise => exercise.Complexity == this.complexity;
    }
}

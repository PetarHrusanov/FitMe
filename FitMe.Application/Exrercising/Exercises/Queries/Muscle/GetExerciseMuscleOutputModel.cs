namespace FitMe.Application.Exrercising.Exercises.Queries.Muscle
{
    using System;
    using FitMe.Application.Common.Mapping;
    using Domain.Exercising.Models.Exercises;

    public class GetExerciseMuscleOutputModel : IMapFrom<Muscle>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalExercises { get; set; }
    }
}

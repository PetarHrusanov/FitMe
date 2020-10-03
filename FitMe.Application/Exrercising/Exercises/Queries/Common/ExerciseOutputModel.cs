namespace FitMe.Application.Exrercising.Exercises.Queries.Common
{
    using System;
    using AutoMapper;
    using FitMe.Application.Common.Mapping;
    using FitMe.Domain.Exercising.Models.Exercises;

    public class ExerciseOutputModel : IMapFrom<Exercise>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string Complexity { get; private set; } = default!;

        public string Muscle { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Exercise, ExerciseOutputModel>()
                .ForMember(ad => ad.Muscle, cfg => cfg
                    .MapFrom(ad => ad.Muscle.Name))
                .ForMember(ad => ad.Complexity, cfg => cfg
                    .MapFrom(ad => ad.Complexity.ToString()));
    }
}

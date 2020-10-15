namespace FitMe.Application.Exrercising.Instructors.Queries.Common
{
    using System;
    using AutoMapper;
    using FitMe.Application.Common.Mapping;
    using FitMe.Domain.Exercising.Models.Instructors;

    public class InstructorOutputModel : IMapFrom<Instructor>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Instructor, InstructorOutputModel>()
                .ForMember(d => d.PhoneNumber, cfg => cfg
                    .MapFrom(d => d.PhoneNumber.Number));
    }
}

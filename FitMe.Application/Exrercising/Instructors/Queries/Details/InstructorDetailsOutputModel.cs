namespace FitMe.Application.Exrercising.Instructors.Queries.Details
{
    using System;
    using AutoMapper;
    using FitMe.Application.Exrercising.Instructors.Queries.Common;
    using FitMe.Domain.Exercising.Models.Instructors;

    public class InstructorDetailsOutputModel : InstructorOutputModel
    {

        public int TotalExercises { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Instructor, InstructorDetailsOutputModel>()
                .IncludeBase<Instructor, InstructorOutputModel>()
                .ForMember(d => d.TotalExercises, cfg => cfg
                    .MapFrom(d => d.Exercises.Count));
    }
}

namespace FitMe.Application.Exrercising.Exercises.Queries.Details
{
    using System;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;
    using FitMe.Application.Exrercising.Instructors.Queries.Common;

    public class ExerciseDetailsOutputModel : ExerciseOutputModel
    {

        public InstructorOutputModel Instructor { get; set; } = default;
        //public bool HasClimateControl { get; private set; }

        //public int NumberOfSeats { get; private set; }

        //public string TransmissionType { get; private set; } = default!;

        //public DealerOutputModel Dealer { get; set; } = default!;

        //public override void Mapping(Profile mapper)
        //    => mapper
        //        .CreateMap<CarAd, CarAdDetailsOutputModel>()
        //        .IncludeBase<CarAd, CarAdOutputModel>()
        //        .ForMember(c => c.HasClimateControl, cfg => cfg
        //            .MapFrom(c => c.Options.HasClimateControl))
        //        .ForMember(c => c.NumberOfSeats, cfg => cfg
        //            .MapFrom(c => c.Options.NumberOfSeats))
        //        .ForMember(c => c.TransmissionType, cfg => cfg
        //            .MapFrom(c => Enumeration.NameFromValue<TransmissionType>(
        //                c.Options.TransmissionType.Value)));
    }
}

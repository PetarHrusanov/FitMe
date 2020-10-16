namespace FitMe.Application.Exrercising.Exercises.Queries.Details
{
    using System;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;
    using FitMe.Application.Exrercising.Instructors.Queries.Common;

    public class ExerciseDetailsOutputModel : ExerciseOutputModel
    {

        public InstructorOutputModel? Instructor { get; set; } = default;

       
    }
}

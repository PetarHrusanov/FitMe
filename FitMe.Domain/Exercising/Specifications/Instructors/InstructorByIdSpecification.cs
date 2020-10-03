namespace FitMe.Domain.Exercising.Specifications.Instructors
{
    using System;
    using System.Linq.Expressions;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Instructors;

    public class InstructorByIdSpecification : Specification<Instructor>
    {
        private readonly int? id;

    public InstructorByIdSpecification(int? id)
        => this.id = id;

    protected override bool Include => this.id != null;

    public override Expression<Func<Instructor, bool>> ToExpression()
        => dealer => dealer.Id == this.id;

    }
}

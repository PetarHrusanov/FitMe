namespace FitMe.Domain.Exercising.Specifications.Instructors
{
    using System;
    using System.Linq.Expressions;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Instructors;

    public class InstructorByNameSpecification : Specification<Instructor>
    {
        private readonly string? name;

    public InstructorByNameSpecification(string? name)
        => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Instructor, bool>> ToExpression()
        => dealer => dealer.Name.ToLower().Contains(this.name!.ToLower());

    }
}

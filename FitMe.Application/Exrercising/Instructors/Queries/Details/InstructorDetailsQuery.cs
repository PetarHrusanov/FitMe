namespace FitMe.Application.Exrercising.Instructors.Queries.Details
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class InstructorDetailsQuery : IRequest<InstructorDetailsOutputModel>
    {
        public int Id { get; set; }

        public class InstructorDetailsQueryHandler : IRequestHandler<InstructorDetailsQuery, InstructorDetailsOutputModel>
        {
            private readonly IInstructorQueryRepository instructorRepository;

            public InstructorDetailsQueryHandler(IInstructorQueryRepository instructorRepository)
                => this.instructorRepository = instructorRepository;

            public async Task<InstructorDetailsOutputModel> Handle(
                InstructorDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.instructorRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}

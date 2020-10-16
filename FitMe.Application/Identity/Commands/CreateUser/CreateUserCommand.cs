namespace FitMe.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using FitMe.Application.Exrercising.Instructors;
    using FitMe.Domain.Exercising.Factories.Instructors;
    using FitMe.Domain.Exercising.Repositories;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            private readonly IInstructorFactory instructorFactory;
            private readonly IInstructorDomainRepository instructorRepository;


            public CreateUserCommandHandler(
                IIdentity identity,
                IInstructorFactory instructorFactory,
                IInstructorDomainRepository instructorRepository)
            {
                this.identity = identity;
                this.instructorFactory = instructorFactory;
                this.instructorRepository = instructorRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var instructor = this.instructorFactory
                    .WithName(request.Name)
                    .WithDescription(request.Description)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeInstructor(instructor);

                await this.instructorRepository.Save(instructor, cancellationToken);

                return result;
            }
        }
    }
}
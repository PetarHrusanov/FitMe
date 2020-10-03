namespace FitMe.Application.Exrercising.Instructors.Commands.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Common.Contracts;
    using FitMe.Domain.Exercising.Repositories;
    using MediatR;

    public class EditInstructorCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class EditInstructorCommandHandler : IRequestHandler<EditInstructorCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IInstructorDomainRepository instructorRepository;

            public EditInstructorCommandHandler(
                ICurrentUser currentUser,
               IInstructorDomainRepository instructorRepository)
            {
                this.currentUser = currentUser;
                this.instructorRepository = instructorRepository;
            }

            public async Task<Result> Handle(
                EditInstructorCommand request,
                CancellationToken cancellationToken)
            {
                var instructor = await this.instructorRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                if (request.Id != instructor.Id)
                {
                    return "You cannot edit this dealer.";
                }

                instructor
                    .UpdateName(request.Name)
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.instructorRepository.Save(instructor, cancellationToken);

                return Result.Success;
            }
        }
    }
}

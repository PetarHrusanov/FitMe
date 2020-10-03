namespace FitMe.Application.Exrercising.Exercises.Commands.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Common.Contracts;
    using FitMe.Application.Exrercising.Instructors;
    using FitMe.Domain.Exercising.Repositories;

    internal static class ChangeExerciseCommand
    {
        public static async Task<Result> InstructorHasExercise(
            this ICurrentUser currentUser,
            IInstructorDomainRepository instructorRepository,
            int carAdId,
            CancellationToken cancellationToken)
        {
            var instructorId = await instructorRepository.GetInstructorId(
                currentUser.UserId,
                cancellationToken);

            var instructorHasExercise = await instructorRepository.HasExercise(
                instructorId,
                carAdId,
                cancellationToken);

            return instructorHasExercise
                ? Result.Success
                : "You cannot edit this car ad.";
        }
    }
}

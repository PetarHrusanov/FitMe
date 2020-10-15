namespace FitMe.Application.Exrercising.Exercises.Queries.Common
{
    //ExerciseQuery

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;

    using FitMe.Domain.Exercising.Models.Exercises;
    using FitMe.Domain.Exercising.Models.Instructors;
    using FitMe.Domain.Exercising.Specifications.Exercises;
    using FitMe.Domain.Exercising.Specifications.Instructors;

    public abstract class ExerciseQuery
    {
        private const int ExercisesPerPage = 10;

        public string? Muscle { get; set; }

        public string? Instructor { get; set; }

        public Complexity Complexity { get; set; }

        public string? SortBy { get; set; }

        public string? Order { get; set; }

        public int Page { get; set; } = 1;

        public abstract class ExercisesQueryHandler
        {
            private readonly IExerciseQueryRepository exerciseRepository;

            protected ExercisesQueryHandler(IExerciseQueryRepository exerciseRepository)
                => this.exerciseRepository = exerciseRepository;

            protected async Task<IEnumerable<TOutputModel>> GetExercisesListings<TOutputModel>(
                ExerciseQuery request,
                //bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var carAdSpecification = this.GetExerciseSpecification(request);

                var dealerSpecification = this.GetInstructorSpecification(request, dealerId);

                var searchOrder = new ExercisesSortOrder(request.SortBy, request.Order);

                var skip = (request.Page - 1) * ExercisesPerPage;

                return await this.exerciseRepository.GetExercisesListings<TOutputModel>(
                    carAdSpecification,
                    dealerSpecification,
                    searchOrder,
                    skip,
                    take: ExercisesPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                ExerciseQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var exerciseSpecification = this.GetExerciseSpecification(request);

                var dealerSpecification = this.GetInstructorSpecification(request, dealerId);

                var totalCarAds = await this.exerciseRepository.Total(
                    exerciseSpecification,
                    dealerSpecification,
                    cancellationToken);

                return (int)Math.Ceiling((double)totalCarAds / ExercisesPerPage);
            }

            private Specification<Exercise> GetExerciseSpecification(ExerciseQuery request)
                => new ExerciseByMuscleSpecification(request.Muscle)
                    .And(new ExerciseByComplexitySpecification(request.Complexity));
                   

            private Specification<Instructor> GetInstructorSpecification(ExerciseQuery request, int? instructorId)
                => new InstructorByIdSpecification(instructorId)
                    .And(new InstructorByNameSpecification(request.Instructor));
        }
    }
}

using System;
namespace FitMe.Application.Exrercising.Exercises.Queries.Common
{
    //ExerciseQuery

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Domain.Dealerships.Specifications.CarAds;
    using Domain.Dealerships.Specifications.Dealers;
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

            protected async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
                ExerciseQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var carAdSpecification = this.GetExerciseSpecification(request, onlyAvailable);

                var dealerSpecification = this.GetInstructorSpecification(request, dealerId);

                var searchOrder = new ExercisesSortOrder(request.SortBy, request.Order);

                var skip = (request.Page - 1) * ExercisesPerPage;

                return await this.exerciseRepository.GetCarAdListings<TOutputModel>(
                    carAdSpecification,
                    dealerSpecification,
                    searchOrder,
                    skip,
                    take: CarAdsPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                CarAdsQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var carAdSpecification = this.GetCarAdSpecification(request, onlyAvailable);

                var dealerSpecification = this.GetDealerSpecification(request, dealerId);

                var totalCarAds = await this.carAdRepository.Total(
                    carAdSpecification,
                    dealerSpecification,
                    cancellationToken);

                return (int)Math.Ceiling((double)totalCarAds / CarAdsPerPage);
            }

            private Specification<Exercise> GetExerciseSpecification(ExerciseQuery request, bool onlyAvailable)
                => new ExerciseByMuscleSpecification(request.Muscle)
                    .And(new ExerciseByComplexitySpecification(request.Complexity));
                   

            private Specification<Instructor> GetInstructorSpecification(ExerciseQuery request, int? instructorId)
                => new InstructorByIdSpecification(instructorId)
                    .And(new InstructorByNameSpecification(request.Instructor));
        }
    }
}

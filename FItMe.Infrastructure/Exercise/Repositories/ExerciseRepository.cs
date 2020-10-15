namespace FItMe.Infrastructure.Exercise.Repositories
{
    using System;
    using FitMe.Infrastructure.Common.Persistence;
    using FitMe.Application.Exrercising.Exercises;
    using FitMe.Domain.Exercising.Models.Exercises;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using FitMe.Domain.Common;
    using FitMe.Domain.Exercising.Models.Instructors;
    using FitMe.Application.Exrercising.Exercises.Queries.Common;
    using System.Threading;
    using FitMe.Application.Exrercising.Exercises.Queries.Details;
    using FitMe.Application.Exrercising.Exercises.Queries.Muscle;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using FitMe.Infrastructure.Common;

    internal class ExerciseRepository : DataRepository<IExerciseDbContext, Exercise>, IExerciseQueryRepository
    {
        private readonly IMapper mapper;

        public ExerciseRepository(IExerciseDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Exercise> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(c => c.Muscle)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var carAd = await this.Data.Exercises.FindAsync(id);

            if (carAd == null)
            {
                return false;
            }

            this.Data.Exercises.Remove(carAd);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        private IQueryable<Exercise> GetExercisesQuery(
            Specification<Exercise> exerciseSpexification,
            Specification<Instructor> instructorSpecification)
            => this
                .Data
                .Instructors
                .Where(instructorSpecification)
                .SelectMany(d => d.Exercises)
                .Where(exerciseSpexification);

        public async Task<IEnumerable<TOutputModel>> GetExercisesListings<TOutputModel>(
            Specification<Exercise> carAdSpecification,
            Specification<Instructor> dealerSpecification,
            ExercisesSortOrder exercisesSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                    .ProjectTo<TOutputModel>(this
                        .GetExercisesQuery(carAdSpecification, dealerSpecification)
                        .Sort(exercisesSortOrder))
                    .ToListAsync(cancellationToken))
                    .Skip(skip)
                    .Take(take); // EF Core bug forces me to execute paging on the client.

        public async Task<ExerciseDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                   .ProjectTo<ExerciseDetailsOutputModel>(this
                       //.AllAvailable()
                       .All()
                       .Where(c => c.Id == id))
                   .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<GetExerciseMuscleQuery>> GetExercisesMuscle(
            string muscleName,
            CancellationToken cancellationToken = default)
            => (IEnumerable<GetExerciseMuscleQuery>)await this
                   .Data
                   .Muscles
                   .FirstOrDefaultAsync(m => m.Name == muscleName, cancellationToken);

        public async Task<int> Total(
            Specification<Exercise> exerciseSpecification,
            Specification<Instructor> instuctorSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetExercisesQuery(exerciseSpecification, instuctorSpecification)
                .CountAsync(cancellationToken);
    }
}

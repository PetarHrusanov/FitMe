namespace FitMe.Infrastructure.Exercise.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FitMe.Application.Exrercising.Instructors;
    using FitMe.Application.Exrercising.Instructors.Queries.Common;
    using FitMe.Application.Exrercising.Instructors.Queries.Details;
    using FitMe.Domain.Exercising.Exceptions;
    using FitMe.Domain.Exercising.Models.Instructors;
    using FitMe.Infrastructure.Common.Persistence;
    using FitMe.Infrastructure.Identity;
    using Microsoft.EntityFrameworkCore;

    internal class InstructorRepository : DataRepository<IExerciseDbContext, Instructor>, IInstructorQueryRepository
    {
        private readonly IMapper mapper;

        public InstructorRepository(IExerciseDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> HasExercise(int instructorId, int exercisedId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(d => d.Id == instructorId)
                .AnyAsync(d => d.Exercises
                    .Any(c => c.Id == exercisedId), cancellationToken);

        public Task<int> GetInstructorId(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Instructor!.Id, cancellationToken);

        public Task<Instructor> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Instructor!, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var instructorData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (instructorData == null)
            {
                throw new InvalidInstructorException("This user is not a instructor.");
            }

            return instructorData;
        }

        public async Task<InstructorDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                    .ProjectTo<InstructorDetailsOutputModel>(this
                        .All()
                        .Where(d => d.Id == id))
                    .FirstOrDefaultAsync(cancellationToken);

        public async Task<InstructorOutputModel> GetDetailsByExerciseId(int exerciseId, CancellationToken cancellationToken = default)
        => await this.mapper
                .ProjectTo<InstructorOutputModel>(this
                    .All()
                    .Where(d => d.Exercises.Any(c => c.Id == exerciseId)))
                .SingleOrDefaultAsync(cancellationToken);
    }
}

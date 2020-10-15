namespace FItMe.Infrastructure.Exercise
{
    using FitMe.Domain.Exercising.Models.Exercises;
    using FitMe.Domain.Exercising.Models.Instructors;
    using FitMe.Infrastructure.Common.Persistence;
    using FitMe.Infrastructure.Identity;
    using Microsoft.EntityFrameworkCore;

    internal interface IExerciseDbContext : IDbContext
    {
        DbSet<Exercise> Exercises { get; }

        DbSet<Muscle> Muscles { get; }

        //DbSet<Manufacturer> Manufacturers { get; }

        DbSet<Instructor> Instructors { get; }

        DbSet<User> Users { get; } // TODO: Temporary workaround
    }
}

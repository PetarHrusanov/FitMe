namespace FitMe.Infrastructure.Common.Persistence
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Statistics.Handlers;
    using AutoMapper;
    using Domain.Statistics.Models;
    using Events;
    using FitMe.Domain.Exercising.Events.Instructor;
    using FitMe.Domain.Exercising.Models.Instructors;
    using FitMe.Infrastructure.Exercise;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Statistics;
    using Xunit;

    public class CarRentalDbContextSpecs
    {
        [Fact]
        public async Task RaisedEventsShouldBeHandled()
        {
            // Arrange
            var services = new ServiceCollection()
                .AddDbContext<ExerciseDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IExerciseDbContext>(provider => provider
                    .GetService<ExerciseDbContext>())
                .AddScoped<IStatisticsDbContext>(provider => provider
                    .GetService<ExerciseDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<IEventHandler<ExerciseAddedEvent>, ExerciseAddedEventHandler>()
                .AddRepositories()
                .BuildServiceProvider();

            var dealer = InstructorFakes.Data.GetInstructor();
            var dbContext = services.GetService<ExerciseDbContext>();

            var statisticsToAdd = new StatisticsData()
                .GetData()
                .First();

            dbContext.Add(statisticsToAdd);
            await dbContext.SaveChangesAsync();

            // Act
            dbContext.Instructors.Add(dealer);
            await dbContext.SaveChangesAsync();

            // Assert
            var statistics = await dbContext.Statistics.SingleAsync();

            statistics.TotalExercises.Should().Be(10);
        }
    }
}

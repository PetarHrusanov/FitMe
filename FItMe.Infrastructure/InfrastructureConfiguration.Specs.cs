namespace FitMe.Infrastructure
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using Common.Events;
    using Common.Persistence;
    using FakeItEasy;
    using FitMe.Application.Exrercising.Exercises;
    using FitMe.Infrastructure.Exercise;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<ExerciseDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IExerciseDbContext>(provider => provider
                    .GetService<ExerciseDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>();

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IExerciseQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}

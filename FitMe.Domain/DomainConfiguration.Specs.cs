namespace FitMe.Domain
{
    using FitMe.Domain.Exercising.Factories.Exercises;
    using FitMe.Domain.Exercising.Factories.Instructors;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IInstructorFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IExerciseFactory>()
                .Should()
                .NotBeNull();
        }
    }
}

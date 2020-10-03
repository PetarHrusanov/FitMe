namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using FitMe.Domain.Exercising.Exceptions;
    using FluentAssertions;
    using Xunit;

    public class MuscleSpecs
    {
        [Fact]
        public void ValidMuscleShouldNotThrowException()
        {
            // Act
            Action act = () => new Muscle("Nov nacepen muscle", "Valid description text", MuscleGroup.Biceps);

            // Assert
            act.Should().NotThrow<InvalidMuscleException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new Muscle("", "", MuscleGroup.Biceps);

            // Assert
            act.Should().Throw<InvalidMuscleException>();
        }
    }
}

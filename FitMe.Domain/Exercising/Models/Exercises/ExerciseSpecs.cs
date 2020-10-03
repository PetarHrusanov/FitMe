namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class ExerciseSpecs
    {
        [Fact]
        public void ChangeExerciseComplexity()
        {
            // Arrange
            var exercise = A.Dummy<Exercise>();

            // Act
            exercise.ChangeComplexity(Complexity.Extreme);

            // Assert
            exercise.Complexity.Should().BeSameAs(Complexity.Extreme);
        }
    }
}

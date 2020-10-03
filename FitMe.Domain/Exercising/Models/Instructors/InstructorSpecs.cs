namespace FitMe.Domain.Exercising.Models.Instructors
{
    using System;
    using FakeItEasy;
    using FitMe.Domain.Exercising.Models.Exercises;
    using FluentAssertions;
    using Xunit;

    public class InstructorSpecs
    {
        [Fact]
        public void AddCarAdShouldSaveCarAd()
        {
            // Arrange
            var instructor = new Instructor("Instruct-cho","Mazniqt instructor", "+12345678");
            var exercise = A.Dummy<Exercise>();

            // Act
            instructor.AddExercise(exercise);

            // Assert
            instructor.Exercises.Should().Contain(exercise);
        }
    }
}

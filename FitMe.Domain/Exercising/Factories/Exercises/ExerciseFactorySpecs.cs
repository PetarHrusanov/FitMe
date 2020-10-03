namespace FitMe.Domain.Exercising.Factories.Exercises
{
    using System;
    using FitMe.Domain.Exercising.Exceptions;
    using FitMe.Domain.Exercising.Models.Exercises;
    using FluentAssertions;
    using Xunit;

    public class ExerciseFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfComplexityIsNoSet()
        {
            // Assert
            var exerciseFactory = new ExerciseFactory();

            // Act
            Action act = () => exerciseFactory
                .WithName("Test")
                .WithInstruction("Test Test")
                .WithDescription("Test Test Test")
                .WithMuscle("Biceps", "Mazen Biceps", MuscleGroup.Biceps)
                .Build();

            // Assert
            act.Should().Throw<InvalidExеrciseException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfMuscleIsNoSet()
        {
            // Assert
            var exerciseFactory = new ExerciseFactory();

            // Act
            Action act = () => exerciseFactory
                .WithName("Test")
                .WithInstruction("Test Test")
                .WithDescription("Test Test Test")
                //.WithMuscle("Biceps", "Mazen Biceps", MuscleGroup.Biceps)
                .WithComplexity(Complexity.Extreme)
                .Build();

            // Assert
            act.Should().Throw<InvalidExеrciseException>();
        }

        // consider Tests on Strings
    }
}

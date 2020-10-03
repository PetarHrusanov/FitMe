namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using FakeItEasy;

    public class ExerciseFakes
    {
        public class CarAdDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Exercise);

            public object? Create(Type type) => Data.GetExercise();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<Exercise> GetExercises(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GetExercise(i))
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(i => GetExercise(i)))
                    .ToList();

            public static Exercise GetExercise(int id = 1)
                => new Faker<Exercise>()
                    .CustomInstantiator(f => new Exercise(
                        f.Lorem.Letter(10),
                        f.Lorem.Letter(10),
                        f.Lorem.Letter(10),
                        Complexity.Extreme,
                        new Muscle("misha", "misha misha", MuscleGroup.Biceps)))
                    .Generate();
        }
    }
}

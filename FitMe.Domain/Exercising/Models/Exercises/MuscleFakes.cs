namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using FakeItEasy;

    public class MuscleFakes
    {
        public class MuscleDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Muscle);

            public object? Create(Type type)
                => new Muscle("Nov nacepen muscle", "Valid description text", MuscleGroup.Biceps);

            public Priority Priority => Priority.Default;
        }
    }
}

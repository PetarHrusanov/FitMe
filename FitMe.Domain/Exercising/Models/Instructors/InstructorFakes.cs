namespace FitMe.Domain.Exercising.Models.Instructors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using static Exercises.ExerciseFakes.Data;

    public class InstructorFakes
    {
        public static class Data
        {
            public static IEnumerable<Instructor> Instructors(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetInstructor)
                    .ToList();

            public static Instructor GetInstructor(int id = 1, int totalCarAds = 10)
            {
                var instructor = new Faker<Instructor>()
                    .CustomInstantiator(f => new Instructor(
                        $"Instructor{id}",
                        "The Best instructor",
                        f.Phone.PhoneNumber("+########")))
                    .Generate();

                foreach (var exercise in GetExercises().Take(totalCarAds))
                {
                    instructor.AddExercise(exercise);
                }

                return instructor;
            }
        }
    }
}

namespace FitMe.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<ExerciseView> exerciseViews;

        internal Statistics()
        {
            this.TotalExercises = 0;

            this.exerciseViews = new HashSet<ExerciseView>();
        }

        public int TotalExercises { get; private set; }

        public IReadOnlyCollection<ExerciseView> ExerciseViews
            => this.exerciseViews.ToList().AsReadOnly();

        public void AddExercise()
            => this.TotalExercises++;

        public void AddExerciseView(int carAdId, string? userId)
            => this.exerciseViews.Add(new ExerciseView(carAdId, userId));
    }
}

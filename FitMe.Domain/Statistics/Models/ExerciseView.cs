namespace FitMe.Domain.Statistics.Models
{
    using System;
    using FitMe.Domain.Common.Models;

    // Really taking a cheap copy shot on this one due to lack of time
    public class ExerciseView : Entity<int>
    {
        internal ExerciseView(int exerciseId, string? userId)
        {
            this.ExerciseId = exerciseId;
            this.UserId = userId;
        }

        public int ExerciseId { get; }

        public string? UserId { get; }
    }
}

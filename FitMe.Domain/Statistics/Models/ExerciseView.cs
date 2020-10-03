namespace FitMe.Domain.Statistics.Models
{
    using System;
    using FitMe.Domain.Common.Models;

    // Really taking a cheap copy shot on this one due to lack of time
    public class ExerciseView : Entity<int>
    {
        internal ExerciseView(int carAdId, string? userId)
        {
            this.CarAdId = carAdId;
            this.UserId = userId;
        }

        public int CarAdId { get; }

        public string? UserId { get; }
    }
}

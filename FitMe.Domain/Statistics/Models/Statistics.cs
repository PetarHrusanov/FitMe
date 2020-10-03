namespace FitMe.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<ExerciseView> carAdViews;

        internal Statistics()
        {
            this.TotalCarAds = 0;

            this.carAdViews = new HashSet<ExerciseView>();
        }

        public int TotalCarAds { get; private set; }

        public IReadOnlyCollection<ExerciseView> CarAdViews
            => this.carAdViews.ToList().AsReadOnly();

        public void AddCarAd()
            => this.TotalCarAds++;

        public void AddCarAdView(int carAdId, string? userId)
            => this.carAdViews.Add(new ExerciseView(carAdId, userId));
    }
}

namespace FitMe.Application.Statistics.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Dealerships.Events.Dealers;

    public class ExerciseAdAddedEventHandler : IEventHandler<CarAdAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ExerciseAdAddedEventHandler(IStatisticsRepository statistics) 
            => this.statistics = statistics;

        public Task Handle(CarAdAddedEvent domainEvent)
            => this.statistics.IncrementCarAds();
    }
}

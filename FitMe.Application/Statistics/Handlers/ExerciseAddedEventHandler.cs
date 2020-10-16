namespace FitMe.Application.Statistics.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using FitMe.Domain.Exercising.Events.Instructor;

    public class ExerciseAddedEventHandler : IEventHandler<ExerciseAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ExerciseAddedEventHandler(IStatisticsRepository statistics) 
            => this.statistics = statistics;

        public Task Handle(ExerciseAddedEvent domainEvent)
            => this.statistics.IncrementExercises();
    }
}

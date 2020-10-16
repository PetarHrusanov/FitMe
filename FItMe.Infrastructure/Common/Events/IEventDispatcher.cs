namespace FitMe.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using FitMe.Domain.Common;

    internal interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}

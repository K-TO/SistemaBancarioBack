using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Report
{
    public interface IReportTopCustomersOutputPort
    {
        Task Handle(TopCustomersBalanceReport topCustomersBalance);
    }
}

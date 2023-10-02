using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Report;

namespace SatrackBank.Presenters.Report
{
    public class ReportTopCustomersPresenter : IReportTopCustomersOutputPort, IPresenter<TopCustomersBalanceReport>
    {
        public TopCustomersBalanceReport Content { get; private set; }

        public Task Handle(TopCustomersBalanceReport report)
        {
            Content = report;
            return Task.CompletedTask;
        }
    }
}

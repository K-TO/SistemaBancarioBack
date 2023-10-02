using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Report;

namespace SatrackBank.Presenters.Report
{
    public class ReportAverageBalancePresenter : IReportAverageBalanceOutputPort, IPresenter<List<AverageBalanceReport>>
    {
        public List<AverageBalanceReport> Content { get; private set; }

        public Task Handle(List<AverageBalanceReport> report)
        {
            Content = report;
            return Task.CompletedTask;
        }
    }
}

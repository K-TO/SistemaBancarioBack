using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Report
{
    public interface IReportAverageBalanceOutputPort
    {
        Task Handle(List<AverageBalanceReport> averageBalance);
    }
}

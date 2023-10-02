using SatrackBank.Entities.Enums;

namespace SatrackBank.UseCasesPorts.Report
{
    public interface IReportAverageBalanceInputPort
    {
        Task Handle(ProductType? productType);
    }
}
